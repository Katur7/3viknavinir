using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class ListTranslationsController : Controller
    {
		const int ITEMSPERPAGE = 10;

        // GET: /ListTranslations/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult AlphabetizedTexts(int? id)
		{
			using(MediaRepo mediarepo = new MediaRepo())
			{
				int realid = 0;
				if(id.HasValue)
				{
					realid = id.Value;
				}

				var allmedia = (from m in mediarepo.GetAllMedia()
								orderby m.title ascending
								select m).ToList();

				var viewModel = new AlphabetizedTextsViewmodel();
				viewModel.pageCount = (allmedia.Count() / ITEMSPERPAGE) + 1;
				viewModel.allMedia = allmedia.Skip(realid * ITEMSPERPAGE).Take(ITEMSPERPAGE);

				if(allmedia != null)
				{
					return View(viewModel);
				}
			}
			return View();
		}
	}
}