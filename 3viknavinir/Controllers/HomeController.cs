using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			// Erla = Grímur er sætur
            // Svava = Steinunn og Svava
			// Grímur = Og ég líka, víí
			// Liljar = verður 3viknavinafeitabolla
 			// Fanney = push aftur
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			// heeeyyyy 
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}