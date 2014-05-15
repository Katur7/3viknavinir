using _3viknavinir;
using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using _3viknavinir.Models.ViewModels;

namespace _3viknavinir.Controllers
{
    [HandleError]
    public class ListRequestController : Controller
    {
		const int ITEMSPERPAGE = 10;

        private RequestRepo requestRepo;

        public ListRequestController( )
        {
            this.requestRepo = new RequestRepo( );
        }

        public ListRequestController( RequestRepo requestRepo )
        {
            this.requestRepo = requestRepo;
        }

		public ActionResult Requests(int? id)
		{
			int realid = 0;
			if(id.HasValue)
			{
				realid = id.Value;
			}
			using (UserRepo userRepo = new UserRepo())
			{
				using (RequestRepo requestRepo = new RequestRepo())
				{
					int count = (from r in requestRepo.GetAllRequests()
								 select r).Count();
					ViewBag.pagecount = (count / ITEMSPERPAGE) + 1;

					var allRequests = (from r in requestRepo.GetAllRequests()
									   join u in userRepo.GetAllUsers() on r.userID equals u.Id
									   orderby r.dateOfRequest descending
									   select new ListRequestViewModel()
									   {
										   Id = r.ID,
										   title = r.title,
										   IMDBId = r.imdbID,
										   yearOfRelease = r.yearOfRelease,
										   requestById = u.Id,
										   requestByName = u.UserName,
										   upvotes = requestRepo.CountUpvotesForRequest(r.ID)
									 
                                       }).Skip(realid * ITEMSPERPAGE).Take(ITEMSPERPAGE).ToList();

					if (allRequests != null)
					{
						return View(allRequests);
					}
				}
				return View();
			}
		}

        [HttpGet]
        [Authorize]
        public ActionResult NewRequest( )
        {
            return View( );
        }
        [HttpPost]
        [Authorize]
        public ActionResult NewRequest( NewRequestViewModel model )
        {
            using ( RequestRepo requestRepo = new RequestRepo( ) )
            {
                if ( ModelState.IsValid )
                {
                        var newRequest = new Requests( );

                        newRequest.title = model.movieName;
                        newRequest.dateOfRequest = DateTime.Now;
                        newRequest.yearOfRelease = model.yearOfRelease;
                        newRequest.imdbID = model.imdbID;
                        newRequest.userID = User.Identity.GetUserId();

                    requestRepo.AddRequest( newRequest );
                    
                    return RedirectToAction("Requests", "ListRequest");
                }
            }
            return View( );
        }

		public void UpvoteRequest(int requestId)
		{
			using (RequestRepo requestRepo = new RequestRepo())
			{
				using (UpvoteRepo upvoteRepo = new UpvoteRepo())
				{
					var id = requestRepo.GetRequestByID(requestId).ID;
					var userId = User.Identity.GetUserId();
					var upvotes = upvoteRepo.GetUpvotesByRequestID(id);
					var userUpvote = (from u in upvotes
									  where u.userID == userId
									  select u).FirstOrDefault();

					if (userUpvote != null)
					{
						return;
					}
					else
					{
						Upvote newUpvote = new Upvote();
						newUpvote.userID = userId;
						newUpvote.translationID = null;
						newUpvote.requestID = id;
						newUpvote.discussionID = null;

						upvoteRepo.AddUpvote(newUpvote);
					}
				}
			}
		}
    }
}