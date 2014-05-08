using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
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
	}
}