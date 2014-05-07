using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class RequestController : Controller
    {
        //
        // GET: /Request/
        public ActionResult Index()
        {
            return View();
        }
	}
}