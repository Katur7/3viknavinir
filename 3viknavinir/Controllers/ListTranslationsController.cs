using _3viknavinir.Models;
using _3viknavinir.Models.ViewModels;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class ListTranslationsController : Controller
    {
		const int ITEMSPERPAGE = 10;

        // GET: /ListTranslations/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AlphabetizedTexts(int? id)
		{
			using (UserRepo userRepo = new UserRepo())
			{
				using (TranslationRepo translationRepo = new TranslationRepo())
				{
					using(MediaRepo mediarepo = new MediaRepo())
					{
						int realid = 0;

						if(id.HasValue)
						{
							realid = id.Value;
						}
						
                        var viewModel = new AlphabetizedTextsViewmodel();

						var count = (from m in mediarepo.GetAllMedia()
											   select m).Count();
						
                        viewModel.pageCount = (count / ITEMSPERPAGE) + 1;

						var allmedia = (from m in mediarepo.GetAllMedia()
										orderby m.title ascending
										select m).Skip(realid * ITEMSPERPAGE).Take(ITEMSPERPAGE);

						viewModel.allMedia = new List<MediaUpvoteViewModel>();
						
                        foreach(var item in allmedia)
						{
							MediaUpvoteViewModel mediaUpvote = new MediaUpvoteViewModel();
							
                            mediaUpvote.media = item;
							
                            var translation = translationRepo.GetTranslationByMediaID(item.ID);
							
                            if(translation != null)
							{
								mediaUpvote.upvotes = translationRepo.GetTranslationByMediaID(item.ID).Upvote.Count;
							}
							
                            viewModel.allMedia.Add(mediaUpvote);
						}

						if(allmedia != null)
						{
							return View(viewModel);
						}
					}
					return View();
				}
			}
		}


		public JsonResult UpvoteMedia(int mediaId)
		{
			using (TranslationRepo translationRepo = new TranslationRepo())
			{
				using(UpvoteRepo upvoteRepo = new UpvoteRepo())
				{
					var translationId = translationRepo.GetTranslationByMediaID(mediaId).ID;
					var userId = User.Identity.GetUserId();
					var upvotes = upvoteRepo.GetUpvotesByTranslationID(translationId);
					
                    var userUpvote = (from u in upvotes
									 where u.userID == userId 
									 select u).FirstOrDefault();
									 
					if(userUpvote != null)				// User has already upvoted this item
					{
						return Json(new { upvotes = (translationRepo.GetTranslationByMediaID(mediaId).Upvote.Count - 1) });
					} 
                    else
					{
						Upvote newUpvote = new Upvote();
						newUpvote.userID = userId;
						newUpvote.translationID = translationId;
						newUpvote.requestID = null;
						newUpvote.discussionID = null;

						upvoteRepo.AddUpvote(newUpvote);
						return Json(new { upvotes = translationRepo.GetTranslationByMediaID(mediaId).Upvote.Count });
					}
				}
			}
		}
	}
}