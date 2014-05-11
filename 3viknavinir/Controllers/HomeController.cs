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
					var newestMedia = (from t in translationRepo.GetAllTranslations()
									   join m in mediaRepo.GetAllMedia() on t.mediaID equals m.Id
									   orderby t.dateAdded descending
									   select m).Take(20);

					var viewModel = new IndexViewModel();
					viewModel.recentMedia = newestMedia;
					 
					if (newestMedia != null)
					{
						return View(viewModel);
					}
				}
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