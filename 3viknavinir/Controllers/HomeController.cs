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
			// Erla = 
			// Svava =
			// Grímur = 
			// Liljar =
 			// Fanney =
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
			var i = 21;
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}