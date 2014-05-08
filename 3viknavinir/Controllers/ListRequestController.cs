using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class ListRequestController : Controller
    {
        //
        // GET: /ListRequest/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Requests()
		{
			return View();
		}

		public ActionResult NewRequest()
		{
			return View();
		}
	}
}