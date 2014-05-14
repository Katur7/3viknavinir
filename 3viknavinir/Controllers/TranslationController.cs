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
using System.IO;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class TranslationController : Controller
    {
        // comment
        // GET: /Translation/
        public ActionResult Index()
        {
            return View();
        }

		public bool HasFile(HttpPostedFileBase file)
		{
			return (file != null && file.ContentLength > 0) ? true : false;
		}

		[Authorize]
        [HttpGet]
        public ActionResult Translate()
        {
            if ( User.Identity.IsAuthenticated )
            {
				using(CategoryRepo categoryRepo = new CategoryRepo())
				{
					MediaDetailsViewModel viewModel = new MediaDetailsViewModel();

					List<Category> categories = categoryRepo.GetAllCategories().ToList();

					viewModel.categories = new List<SelectListItem>();

					foreach (Category category in categories)
					{
						viewModel.categories.Add(new SelectListItem() { Text = category.name, Value = category.ID.ToString() });
					}
					return View(viewModel);
				}
				
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
                        Media newMedia = new Media( );

                        newMedia.title = media.title;
                        newMedia.yearOfRelease = media.yearOfRelease;
                        newMedia.description = media.description;
                        newMedia.categoryID = media.category;
                        newMedia.imdbID = media.imdbID;

						mediaRepo.AddMedia(newMedia);

                        var newTranslation = new Translation();

                        //int nextTranslationID = translationRepo.GetNextTranslationID();

                        //newTranslation.ID = nextTranslationID;
                        newTranslation.languageID = 1; 
                        newTranslation.mediaID = newMedia.ID;
                        newTranslation.finished = false; 
                        newTranslation.userID = User.Identity.GetUserId();
                        newTranslation.dateAdded = DateTime.Now;
                        
                        translationRepo.AddTranslation( newTranslation );

						BinaryReader b = new BinaryReader(media.srtFile.InputStream);
						byte[] binData = b.ReadBytes((int)media.srtFile.InputStream.Length);
						string result = System.Text.Encoding.UTF8.GetString(binData);

						var lines = result.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
						foreach(var line in lines)
						{
							System.Diagnostics.Debug.WriteLine(line);
						}

                        return RedirectToAction("EditTranslation", "Translation", new {ID = newTranslation.mediaID});
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

							viewModel.userName = userRepo.GetUserNameByID(translation.userID);
								
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
							viewModel.imdbId = media.imdbID;
							
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
					/*
					string path = Server.MapPath("~/Content/posterImg/");

					if (media.choosePoster != null)
					{
						if (media.choosePoster.ContentLength > 102400)
						{
							ModelState.AddModelError("choosePoster", "Stærð myndarinnar ætti ekki að fara yfir 100 KB");
							return View(media);
						}

						var supportedTypes = new[] { "jpg", "jpeg" };

						var fileExt = System.IO.Path.GetExtension(media.choosePoster.FileName).Substring(1);

						if (!supportedTypes.Contains(fileExt))
						{
							ModelState.AddModelError("choosePoster", "Vitlaus skráarending. Aðeins jpg og jpeg skrár eru studdar.");
							return View(media);
						}

						media.choosePoster.SaveAs(path + media.ID + ".jpg");
						newMedia.posterPath = "/Content/posterImg/" + media.ID + ".jpg";
					} else
					{
						newMedia.posterPath = media.posterPath;
					}
						*/
					
					newMedia.ID = media.ID;
					newMedia.title = media.title;
					newMedia.yearOfRelease = media.year;
					newMedia.description = media.description;
					newMedia.categoryID = media.category;
					newMedia.imdbID = media.imdbId;
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
				int realid = id.Value;

				using (MediaRepo mediaRepo = new MediaRepo())
				{
					if(mediaRepo.IsExistingID(realid))
					{
						EditTranslationViewModel viewModel = new EditTranslationViewModel();

						using (TranslationRepo translationRepo = new TranslationRepo())
						{
							var translation = translationRepo.GetTranslationByMediaID(realid);

							var media = mediaRepo.GetMediaByID(translation.mediaID);
							viewModel.title = media.title;
							viewModel.year = media.yearOfRelease;

							using (TranslationLinesRepo translationLinesRepo = new TranslationLinesRepo())
							{
								var translationLines = from tl in translationLinesRepo.GetTranslationLinesByTranslationID(realid)
													   orderby tl.chapterNumber
													   select tl;

								viewModel.textToTranslate = translationLines;
								viewModel.translatedText = translationLines;


								viewModel.isFinished = translation.finished;

								return View(viewModel);
							}
						}
					} else
					{
						return HttpNotFound();
					}
                }
            }
			return HttpNotFound();  // Should be Error/404
        }

        [HttpPost]
        public ActionResult EditTranslation( FormCollection translationLines )
        {
            return View( );
        }

		public ActionResult Discussion()
		{
			return View( );
		}

        public ActionResult Download()
        {
            return View();
        }
	}
}
