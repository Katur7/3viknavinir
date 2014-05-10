using _3viknavinir.Repo;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			using(MediaRepo mediaRepo = new MediaRepo())
			{
				using(TranslationRepo translationRepo = new TranslationRepo())
				{
					/*
					// TODO Fix so it ordersby date from Translations
					var newestMedia = from t in translationRepo.GetAllTranslations()
									  join m in mediaRepo.GetAllMedia() on t.mediaID equals m.Id
									  orderby t.
					*/

					var newestMedia = (from m in mediaRepo.GetAllMedia()
									   orderby m.title ascending
									   select m).Take(25);
					 
					if (newestMedia != null)
					{
						return View(newestMedia);
					}
				}
				
				
				//FrontpageViewModel model = new FrontpageViewModel();
				//model.newestMedia = mediaRepo.GetAllMedia().Take(25);
				//if(model.newestMedia != null)
				//{
				//	return View(model);
				//}
			}
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult FAQ()
		{
			ViewBag.Message = "Algengar spurningar.";

			return View();
		}

        public ActionResult ForgotPassword()
        {
            ViewBag.Message = "Gleymt Lykilorð";

            return View();
        }
	}
}