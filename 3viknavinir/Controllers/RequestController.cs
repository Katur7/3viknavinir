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
        [Authorize]
        public ActionResult Add( Requests request )
        {
            using ( RequestRepo requestRepo = new RequestRepo( ) )
            {
                var newRequest = new Requests( );

                if ( ModelState.IsValid )
                {
                        requestRepo.AddRequest( newRequest );
                        return RedirectToAction("Requests", "ListRequest");
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