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
        private RequestRepo requestRepo;

        public ListRequestController( )
        {
            this.requestRepo = new RequestRepo( );
        }

        public ListRequestController( RequestRepo requestRepo )
        {
            this.requestRepo = requestRepo;
        }

        public ActionResult Requests( )
        {
			using (UserRepo userRepo = new UserRepo())
			{			
				using (RequestRepo requestRepo = new RequestRepo( ) )
				{
					var allRequests = ( from r in requestRepo.GetAllRequests()
										join u in userRepo.GetAllUsers() on r.userID equals u.Id
										orderby r.title ascending
										select new ListRequestViewModel() { Id = r.ID, title = r.title, IMDBId = r.imdbID, yearOfRelease = r.yearOfRelease, requestById = u.Id, requestByName = u.UserName }).ToList();

					if ( allRequests != null )
					{
						return View( allRequests );
					}
				}
				return View( );
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

    }
}