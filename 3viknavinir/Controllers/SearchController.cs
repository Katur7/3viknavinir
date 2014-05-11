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
							var movies = (from m in mediaRepo.GetMediaLike(searchString)
										  select m);

							/*var moviesByYear = (from m in mediaRepo.GetMediaByYear(searchString)
												select m);

							var moviesByCategory = (from m in mediaRepo.GetMediaByCategory(searchString)
												  select m);

							var moviesByIMDBId = (from m in mediaRepo.GetMediaByImdbID(searchString)
												  select m);*/

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