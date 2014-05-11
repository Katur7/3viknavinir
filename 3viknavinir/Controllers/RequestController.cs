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
    public class RequestController : Controller
    {
        //
        // GET: /Request/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add( int? id )
        {
            if ( id.HasValue )
            {
                int realid = id.Value;
                using ( RequestRepo requestRepo = new RequestRepo() )
                {
                    return View();
                }
            }
            return View( );
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
	}
}