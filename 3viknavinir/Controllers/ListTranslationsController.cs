using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class ListTranslationsController : Controller
    {
        // GET: /ListTranslations/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AlphabetizedTexts()
		{
			using(MediaRepo mediarepo = new MediaRepo())
			{
				var allmedia = mediarepo.GetAllMedia();
				if(allmedia != null)
				{
					return View(allmedia);
				}
			}
			return View();
		}
	}
}