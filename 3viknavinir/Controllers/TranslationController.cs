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
using System.Text;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class TranslationController : Controller
    {
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

                        newTranslation.languageID = 1; 
                        newTranslation.mediaID = newMedia.ID;
                        newTranslation.finished = false; 
                        newTranslation.userID = User.Identity.GetUserId();
                        newTranslation.dateAdded = DateTime.Now;
                        
                        translationRepo.AddTranslation( newTranslation );

						if(media.srtFile != null)
						{
							UploadTranslation(media.srtFile, newTranslation.ID);
						}
						

                        return RedirectToAction("EditTranslation", "Translation", new {ID = newTranslation.mediaID});
                     }
                }
            }
            return View();
        }

		public void UploadTranslation(HttpPostedFileBase srt, int translationId)
		{
			BinaryReader b = new BinaryReader(srt.InputStream);
			byte[] binData = b.ReadBytes((int)srt.InputStream.Length);
			string result = System.Text.Encoding.UTF8.GetString(binData);

			var lines = result.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			// RegExPatterns to match TranslationLine setup
			string timeLinePattern = "([0-9]{2}:{1}){2}[0-9]{2},[0-9]{3}.(-->).([0-9]{2}:{1}){2}[0-9]{2},[0-9]{3}";
			string subtitlepattern = "[a-z|A-Z]+";
			string timePattern = "[a-z|A-Z]*([0-9]{2}:{1}){2}[0-9]{2},[0-9]{3}";
			string chapterPattern = "[0-9]+";

			List<string> reverseAllLines = new List<string>();
			foreach (var line in lines)
			{
				reverseAllLines.Add(line);
			}
			List<string> allLines = new List<string>();
			foreach (var item in reverseAllLines)
			{
				allLines.Add(item);
			}
			using (TranslationLinesRepo translationLinesRepo = new TranslationLinesRepo())
			{
				TranslationLines newTranslationLine = new TranslationLines();
				var count = allLines.Count;
				for (int i = 0; i < count; i++)
				{
					var line = allLines[i];
					if (Regex.IsMatch(line, timeLinePattern))				// Timeline, split up, second
					{
						var times = Regex.Matches(line, timePattern);
						newTranslationLine.startTime = times[0].ToString();
						newTranslationLine.endTime = times[1].ToString();
					}
					else if (Regex.IsMatch(line, subtitlepattern))			// Subtitle, last
					{
						newTranslationLine.subtitle = line;
						if((i + 1) < count)
						{
							if (!char.IsDigit(allLines[i + 1][0]))			// If subtitle is in two lines
							{
								newTranslationLine.subtitle += " " + Environment.NewLine + allLines[i + 1];
								i++;
							}
						}
						
						newTranslationLine.isEditing = false;
						newTranslationLine.dateOfSubmission = DateTime.Now;
						newTranslationLine.translationID = translationId;
						translationLinesRepo.AddOrUpdateTranslationLine(newTranslationLine);
					}
					else if(Regex.IsMatch(line, chapterPattern))			// ChapterNumber, first
					{
						newTranslationLine.chapterNumber = Convert.ToInt32(line);
					}
				}
			}
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
							if(!mediaRepo.IsExistingID(realid))
							{
								return RedirectToAction("Error404", "Home");
							}
							var media = mediaRepo.GetMediaByID(realid);
							if(!translationRepo.IsExistingMediaID(media.ID))
							{
								return RedirectToAction("Error404", "Home");
							}
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
			return RedirectToAction("Error404", "Home");
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
					mediaRepo.UpdateMedia( newMedia );

					if(media.srtFile != null)
					{
						int translationId = 0;
						using(TranslationRepo translationRepo = new TranslationRepo())
						{
							translationId = translationRepo.GetTranslationByMediaID(newMedia.ID).ID;
						}
						UploadTranslation(media.srtFile, translationId);
					}

					return RedirectToAction("AlphabetizedTexts", "ListTranslations");
				}
			}
			return View(media);
		}

        [HttpGet]
        [Authorize]
        public ActionResult EditTranslation( int? id, int? page)
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
                            viewModel.mediaID = media.ID;

							int realPage = 0;
							if (page.HasValue)
							{
								realPage = page.Value;
							}

							using (TranslationLinesRepo translationLinesRepo = new TranslationLinesRepo())
							{
								var count = (from tl in translationLinesRepo.GetTranslationLinesByTranslationID(translation.ID)
											 select tl).Count();
								viewModel.pageCount = (count / 50) + 1;

								var translationLines = (from tl in translationLinesRepo.GetTranslationLinesByTranslationID(translation.ID)
													   orderby tl.chapterNumber
													   select tl).Skip(realPage * 50).Take(50);

								viewModel.textToTranslate = translationLines;
								viewModel.translatedText = translationLines;
								viewModel.counter = translationLines.Count();

								viewModel.isFinished = translation.finished;

								return View(viewModel);
							}
						}
					} else
					{
						return RedirectToAction("Error404", "Home");;
					}
                }
            }
			return RedirectToAction("Error404", "Home");
        }

        [HttpPost]
		public JsonResult EditTranslation(string json)
        {
			TranslatedTextViewModel model = new JavaScriptSerializer().Deserialize<TranslatedTextViewModel>(json);
			using(TranslationRepo translationRepo = new TranslationRepo())
			{
				var translation = translationRepo.GetTranslationByMediaID(model.mediaID);
				translation.finished = model.isFinished;

				using(TranslationLinesRepo translationLinesRepo = new TranslationLinesRepo() )
				{
					foreach(var item in model.textToTranslate)
					{
						TranslationLines newTranslationLine = new TranslationLines();
						newTranslationLine.chapterNumber = item.chapterNumber;
						newTranslationLine.startTime = item.startTime;
						newTranslationLine.endTime = item.endTime;
						newTranslationLine.subtitle = item.subtitle;
						newTranslationLine.isEditing = false;
						newTranslationLine.dateOfSubmission = DateTime.Now;
						newTranslationLine.translationID = translation.ID;

						translationLinesRepo.AddOrUpdateTranslationLine(newTranslationLine);
					}
				}
			}
			return Json(new { mediaId = model.mediaID });
        }

		public ActionResult Discussion()
		{
			return View( );
		}

        public ActionResult Download(int? id)
        {
			var mediaId = id.Value;
			string titleYear;
			int translationId;
			using(MediaRepo mediaRepo = new MediaRepo())
			{
				var media = mediaRepo.GetMediaByID(mediaId);
				titleYear = media.title + ".(" + media.yearOfRelease + ")";
				using(TranslationRepo translationRepo = new TranslationRepo())
				{
					translationId = translationRepo.GetTranslationByMediaID(mediaId).ID;
				}
			}
            using (TranslationLinesRepo translationRepo = new TranslationLinesRepo())
            {
				var translationLines = translationRepo.GetTranslationLinesByTranslationID(translationId);

				string document = "";
				foreach(var item in translationLines)
				{
					document += item.chapterNumber.ToString() + Environment.NewLine;
					document += item.startTime.ToString() + " --> " + item.endTime.ToString() + Environment.NewLine;
					document += item.subtitle.ToString() + Environment.NewLine;
					document += Environment.NewLine;
				}

				return File(Encoding.UTF8.GetBytes(document),
				 "text/srt",
				  titleYear + ".srt");

            }
        }
	}
}
