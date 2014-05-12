using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class TranslationController : Controller
    {
        //
        // GET: /Translation/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Translate()
        {
            if ( User.Identity.IsAuthenticated )
            {
                return View( );
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
		public ActionResult Translate(MediaDetailsViewModel media)
		{
            using(MediaRepo mediaRepo = new MediaRepo())
            {
                using(TranslationRepo translationRepo = new TranslationRepo())
                {
                    if ( ModelState.IsValid )
                    {
                        var newMedia = new Media( );

                        int nextMediaID = mediaRepo.GetNextMediaID( );

                        newMedia.Id = nextMediaID;
                        newMedia.title = media.title;
                        newMedia.yearOfRelease = media.yearOfRelease;
                        newMedia.description = media.description;
                        newMedia.categoryID = 1; // TODO
                        newMedia.imdbID = media.imdbID;
                        newMedia.posterPath = "~/Content/siat_logo.jpg";

                        var newTranslation = new Translation();

                        int nextTranslationID = translationRepo.GetNextTranslationID();

                        newTranslation.Id = nextTranslationID;
                        newTranslation.languageID = 1; // TODO
                        newTranslation.mediaID = newMedia.Id;
                        newTranslation.finished = false; // TODO
                        newTranslation.userID = User.Identity.GetUserId(); // TODO Username
                        newTranslation.dateAdded = DateTime.Now;


                        mediaRepo.AddMedia( newMedia );
                        translationRepo.AddTranslation(newTranslation);
                        return RedirectToAction( "AlphabetizedTexts", "ListTranslations" );
                     }
                }
            }
            return View();
        }

		public ActionResult Details(int? id)
		{
			var viewModel = new MediaDetailsViewModel();
			if (id.HasValue)
			{
				int realid = id.Value;
				using(MediaRepo mediaRepo = new MediaRepo())
				{
					using(TranslationRepo translationRepo = new TranslationRepo())
					{
						var media = mediaRepo.GetMediaByID(realid);
						var translation = translationRepo.GetTranslationByMediaID(realid);
						/*
						List<MembershipUser> allUsers = Membership.GetAllUsers();
						MembershipUser mu1 = (from u in allUsers
								   where u.UserID == translation.userID
								   select u).SingleOrDefault();
						MembershipUser mu = Membership.GetUser(translation.userID);
						string userName = mu.UserName;
						*/
						viewModel.media = media;
						viewModel.translation = translation;
						//viewModel.userName = userName;

						if (media != null && translation != null)
						{
							return View(viewModel);
						}
					}
				}
			}
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
        [Authorize]
		public ActionResult Edit(int? id)
		{
			if(id.HasValue)
			{
				int realid = id.Value;
				using(MediaRepo mediaRepo = new MediaRepo())
				{
					var media = mediaRepo.GetMediaByID(realid);
					if(media != null)
					{
						return View(media);
					}
				}
			}
			return View();
		}

		[HttpPost]
		public ActionResult Edit()
		{

			return View();
		}

        [HttpGet]
        [Authorize]
        public ActionResult EditTranslation( int? id)
        {
            if ( id.HasValue )
            {
				EditTranslationViewModel viewModel = new EditTranslationViewModel();

                int realid = id.Value;
                using ( TranslationLinesRepo translationLinesRepo = new TranslationLinesRepo( ) )
                {
					using (TranslationRepo translationRepo = new TranslationRepo())
					{ 
						using(MediaRepo mediaRepo = new MediaRepo())
						{
							var translationLines = from tl in translationLinesRepo.GetTranslationLinesByTranslationID(realid)
												   orderby tl.chapterNumber
												   select tl;

							viewModel.textToTranslate = translationLines;
							viewModel.translatedText = translationLines;

							var translation = translationRepo.GetTranslationByID(realid);
							viewModel.isFinished = translation.finished;

							var media = mediaRepo.GetMediaByID(translation.mediaID);
							viewModel.title = media.title;
							viewModel.year = media.yearOfRelease;
						

							if ( translationLines != null && translation != null && media != null)
							{
								return View( viewModel );
							}
						}
					}
                }
            }
			return RedirectToAction("Index", "Home");  // Should be Error/404
        }

        [HttpPost]
        public ActionResult EditTranslation( )
        {
            return View( );
        }

		public ActionResult Discussion()
		{
			return View( );
		}
	}
}
