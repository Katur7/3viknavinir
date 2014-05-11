using _3viknavinir.Repo;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

		public ActionResult SearchResults(string searchString)
		{
			using (MediaRepo mediaRepo = new MediaRepo())
			{
				using (CategoryRepo categoryRepo = new CategoryRepo())
				{
					using (TranslationRepo translationRepo = new TranslationRepo())
					{
						var movies = (from m in mediaRepo.GetAllMedia()
										   select m);

						if(!String.IsNullOrEmpty(searchString))
						{
							movies = movies.Where(s => s.title.Contains(searchString));
						}

					}
				}
			}

			return View( );
		}
	}
}