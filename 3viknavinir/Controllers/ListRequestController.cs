using _3viknavinir;
using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

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

		[HttpPost]
		public ActionResult NewRequest(NewRequestViewModel model)
		{
			/*string bla = "";
			using (RequestRepo repo = new RequestRepo())
			{
				repo.AddRequest(new Requests() {
					title = model.movieName,
					yearOfRelease = model.yearOfRelease,
					imdbID = model.imdbID,
					userID = User.Identity.GetUserId()
				});
			}
			*/

			return View();
		}
	}
}