﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

		public ActionResult Translate()
		{
			return View();
		}
	}
}