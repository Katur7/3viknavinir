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
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Categories()
		{
			return View();
		}
        public ActionResult Documentary()
        {
            return View();
        }
        public ActionResult Action()
        {
            return View();
        }
        public ActionResult Adventure()
        {
            return View();
        }
        public ActionResult Anime()
        {
            return View();
        }
        public ActionResult Comedy()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID(1)
                                 orderby m.title descending
                                 select m);
                if ( comedies != null)
                {
                    return View( comedies );
                }
            }
            return View();
        }
        public ActionResult Drama()
        {
            return View();
        }
        public ActionResult Family()
        {
            return View();
        }
        public ActionResult Horror()
        {
            return View();
        }
        public ActionResult Icelandic()
        {
            return View();
        }
        public ActionResult Kids()
        {
            return View();
        }
        public ActionResult Musical()
        {
            return View();
        }
        public ActionResult Romantic()
        {
            return View();
        }
        public ActionResult Scifi()
        {
            return View();
        }
        public ActionResult Show()
        {
            return View();
        }
        public ActionResult Thriller()
        {
            return View();
        }
	}
}