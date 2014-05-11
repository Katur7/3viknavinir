using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _3viknavinir.Controllers
{
	[HandleError]
    public class TranslationController : Controller
    {
        //
        // GET: /Translation/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Translate()
		{
			return View();
		}

		public ActionResult Details(int? id)
		{
			var viewModel = new MediaDetailsViewModel();
			if (id.HasValue)
			{
				int realid = id.Value;
				using(MediaRepo mediaRepo = new MediaRepo())
				{
					using(TranslationRepo translationRepo = new TranslationRepo())
					{
						var media = mediaRepo.GetMediaByID(realid);
						var translation = translationRepo.GetTranslationByMediaID(realid);
						/*
						List<MembershipUser> allUsers = Membership.GetAllUsers();
						MembershipUser mu1 = (from u in allUsers
								   where u.UserID == translation.userID
								   select u).SingleOrDefault();
						MembershipUser mu = Membership.GetUser(translation.userID);
						string userName = mu.UserName;
						*/
						viewModel.media = media;
						viewModel.translation = translation;
						//viewModel.userName = userName;

						if (media != null && translation != null)
						{
							return View(viewModel);
						}
					}
				}
			}
			return View();
		}
		[HttpGet]
        [Authorize]
		public ActionResult Edit(int? id)
		{
			if(id.HasValue)
			{
				int realid = id.Value;
				using(MediaRepo mediaRepo = new MediaRepo())
				{
					var media = mediaRepo.GetMediaByID(realid);
					if(media != null)
					{
						return View(media);
					}
				}
			}
			return View();
		}

		[HttpPost]
		public ActionResult Edit()
		{

			return View();
		}

        [HttpGet]
        [Authorize]
        public ActionResult EditTranslation( int? id)
        {
            if ( id.HasValue )
            {
                int realid = id.Value;
                using ( TranslationLinesRepo translationLinesRepo = new TranslationLinesRepo( ) )
                {
                    var translationLine = translationLinesRepo.GetTranslationLineByID(realid);
                    if ( translationLine != null )
                    {
                        return View( translationLine );
                    }
                }
            }
            return View( );
        }

        [HttpPost]
        public ActionResult EditTranslation( )
        {
            return View( );
        }

		public ActionResult Discussion()
		{
			return View( );
		}
	}
}
