﻿using _3viknavinir.Repo;
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
			using(TranslationRepo translationrepo = new TranslationRepo())
			{
				translationrepo.GetAllTranslations();
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