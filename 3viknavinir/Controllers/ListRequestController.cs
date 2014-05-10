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
		private RequestRepo requestRepo;

		public ListRequestController()
		{
			this.requestRepo = new RequestRepo();
		}

		public ListRequestController(RequestRepo requestRepo)
		{
			this.requestRepo = requestRepo;
		}

		public ActionResult Requests()
		{
			//var model = db.News.OrderByDescending(n => n.DateCreated).Take(10);

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