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

		public ActionResult SearchMediaView(string searchString)
		{
			using (MediaRepo mediaRepo = new MediaRepo())
			{
				using (CategoryRepo categoryRepo = new CategoryRepo())
				{
					using (TranslationRepo translationRepo = new TranslationRepo())
					{
						if(!String.IsNullOrEmpty(searchString))
						{
							var movies = (from m in mediaRepo.GetMediaByTitle(searchString)
										  select m); 

							//movies = movies.Where(s => s.title.Contains(searchString));

							var viewModel = new SearchMediaViewModel();
							viewModel.searchedMedia = movies;

							if (movies != null)
							{
								return View(viewModel);
							}
						}

					}
				}
			}

			return View( );
		}
	}
}