using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using _3viknavinir.Models.ViewModels;

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

                        //int nextMediaID = mediaRepo.GetNextMediaID( );

                        //newMedia.ID = nextMediaID;
                        newMedia.title = media.title;
                        newMedia.yearOfRelease = media.yearOfRelease;
                        newMedia.description = media.description;
                        newMedia.categoryID = 41; // TODO
                        newMedia.imdbID = media.imdbID;
                        newMedia.posterPath = "~/Content/siat_logo.jpg"; //TODO
						mediaRepo.AddMedia(newMedia);

                        var newTranslation = new Translation();

                        //int nextTranslationID = translationRepo.GetNextTranslationID();

                        //newTranslation.ID = nextTranslationID;
                        newTranslation.languageID = 10; // TODO
                        newTranslation.mediaID = newMedia.ID;
                        newTranslation.finished = false; // TODO
                        newTranslation.userID = User.Identity.GetUserId(); // TODO UserRepo
                        newTranslation.dateAdded = DateTime.Now;


                        
                        translationRepo.AddTranslation( newTranslation );
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
						using(UserRepo userRepo = new UserRepo())
						{
							var media = mediaRepo.GetMediaByID(realid);
							var translation = translationRepo.GetTranslationByMediaID(realid);

							viewModel.userName = userRepo.GetUserByID(translation.userID).UserName;
								
							viewModel.media = media;
							viewModel.translation = translation;

							if (media != null && translation != null)
							{
								return View(viewModel);
							}
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
			if (id.HasValue)
			{
				int realid = id.Value;
				using (MediaRepo mediaRepo = new MediaRepo())
				{
					using(CategoryRepo categoryRepo = new CategoryRepo())
					{
						EditDetailsViewModel viewModel = new EditDetailsViewModel();

						var media = mediaRepo.GetMediaByID(realid);
						if (media != null)
						{
							viewModel.ID = media.ID;
							viewModel.title = media.title;
							viewModel.year = media.yearOfRelease;
							viewModel.description = media.description;
							viewModel.posterPath = media.posterPath;
							
							List<Category> categories = categoryRepo.GetAllCategories().ToList();

							viewModel.categories = new List<SelectListItem>();

							foreach (Category category in categories)
							{
								viewModel.categories.Add(new SelectListItem() { Text = category.name, Value = category.ID.ToString() });
							}

							return View(viewModel);
						}
					}
				}
			}

			return HttpNotFound();
		}

		[HttpPost]
		public ActionResult Edit(EditDetailsViewModel media)
		{
			using (MediaRepo mediaRepo = new MediaRepo())
			{
				if (ModelState.IsValid)
				{
					Media newMedia = new Media();

					newMedia.ID = media.ID;
					newMedia.title = media.title;
					newMedia.yearOfRelease = media.year;
					newMedia.description = media.description;
					newMedia.categoryID = media.category;
					newMedia.imdbID = media.imdbId;
					newMedia.posterPath = "~/Content/siat_logo.jpg"; //TODO
					mediaRepo.UpdateMedia( newMedia );

					return RedirectToAction("AlphabetizedTexts", "ListTranslations");
				}
			}
			return View(media);
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
