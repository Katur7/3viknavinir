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
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Categories()
		{
			return View();
		}
        public ActionResult Documentary()
        {
            return View();
        }
        public ActionResult Action()
        {
            return View();
        }
        public ActionResult Adventure()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 0 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Anime()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 13 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Comedy()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 1 )
                                 orderby m.title descending
                                 select m);
                if ( comedies != null)
                {
                    return View( comedies );
                }
            }
            return View();
        }
        public ActionResult Drama()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 10 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Family()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 2 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Horror()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 7 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Icelandic()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 3 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Kids()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 9 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Musical()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 4 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Romantic()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 5 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Scifi()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 11 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Show()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 12 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Thriller()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var comedies = ( from m in mediaRepo.GetMediaByCategoryID( 6 )
                                 orderby m.title descending
                                 select m );
                if ( comedies != null )
                {
                    return View( comedies );
                }
            }
            return View( );
        }
        public ActionResult Other()
        {
            using (MediaRepo mediaRepo = new MediaRepo())
            {
                var comedies = (from m in mediaRepo.GetMediaByCategoryID(15)
                                orderby m.title descending
                                select m);
                if (comedies != null)
                {
                    return View(comedies);
                }
            }
            return View();
        }
	}
}