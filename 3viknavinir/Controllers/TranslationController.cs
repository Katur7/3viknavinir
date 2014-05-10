using _3viknavinir.Repo;
using System;
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

		public ActionResult Details(int? id)
		{
			if (id.HasValue)
			{
				int realid = id.Value;
				using(MediaRepo mediaRepo = new MediaRepo())
				{
					var media = mediaRepo.GetMediaByID(realid);

					if (media != null)
					{
						return View(media);
					}
				}
			}
			return View();
		}
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if(id.HasValue)
			{
				int realid = id.Value;
				using(MediaRepo mediaRepo = new MediaRepo())
				{
					var media = mediaRepo.GetMediaByID(realid);
					if(media != null)
					{
						return View(media);
					}
				}
			}
			return View();
		}

		[HttpPost]
		public ActionResult Edit()
		{
			return View();
		}
	}
}
