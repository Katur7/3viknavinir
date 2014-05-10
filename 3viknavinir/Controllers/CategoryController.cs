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
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var documentaries = ( from m in mediaRepo.GetMediaByCategoryID( 14 )
                                   orderby m.title descending
                                   select m );
                if ( documentaries != null )
                {
                    return View( documentaries );
                }
            }
            return View( );
        }
        public ActionResult Action()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var actions = ( from m in mediaRepo.GetMediaByCategoryID( 8 )
                                   orderby m.title descending
                                   select m );
                if ( actions != null )
                {
                    return View( actions );
                }
            }
            return View( );
        }
        public ActionResult Adventure()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var adventures = ( from m in mediaRepo.GetMediaByCategoryID( 0 )
                                 orderby m.title descending
                                 select m );
                if ( adventures != null )
                {
                    return View( adventures );
                }
            }
            return View( );
        }
        public ActionResult Anime()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var anime = ( from m in mediaRepo.GetMediaByCategoryID( 13 )
                                 orderby m.title descending
                                 select m );
                if ( anime != null )
                {
                    return View( anime );
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
                var drama = ( from m in mediaRepo.GetMediaByCategoryID( 10 )
                                 orderby m.title descending
                                 select m );
                if ( drama != null )
                {
                    return View( drama );
                }
            }
            return View( );
        }
        public ActionResult Family()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var family = ( from m in mediaRepo.GetMediaByCategoryID( 2 )
                                 orderby m.title descending
                                 select m );
                if ( family != null )
                {
                    return View( family );
                }
            }
            return View( );
        }
        public ActionResult Horror()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var horror = ( from m in mediaRepo.GetMediaByCategoryID( 7 )
                                 orderby m.title descending
                                 select m );
                if ( horror != null )
                {
                    return View( horror );
                }
            }
            return View( );
        }
        public ActionResult Icelandic()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var icelandics = ( from m in mediaRepo.GetMediaByCategoryID( 3 )
                                 orderby m.title descending
                                 select m );
                if ( icelandics != null )
                {
                    return View( icelandics );
                }
            }
            return View( );
        }
        public ActionResult Kids()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var kids = ( from m in mediaRepo.GetMediaByCategoryID( 9 )
                                 orderby m.title descending
                                 select m );
                if ( kids != null )
                {
                    return View( kids );
                }
            }
            return View( );
        }
        public ActionResult Musical()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var musicals = ( from m in mediaRepo.GetMediaByCategoryID( 4 )
                                 orderby m.title descending
                                 select m );
                if ( musicals != null )
                {
                    return View( musicals );
                }
            }
            return View( );
        }
        public ActionResult Romantic()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var romantics = ( from m in mediaRepo.GetMediaByCategoryID( 5 )
                                 orderby m.title descending
                                 select m );
                if ( romantics != null )
                {
                    return View( romantics );
                }
            }
            return View( );
        }
        public ActionResult Scifi()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var scifis = ( from m in mediaRepo.GetMediaByCategoryID( 11 )
                                 orderby m.title descending
                                 select m );
                if ( scifis != null )
                {
                    return View( scifis );
                }
            }
            return View( );
        }
        public ActionResult Show()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var shows = ( from m in mediaRepo.GetMediaByCategoryID( 12 )
                                 orderby m.title descending
                                 select m );
                if ( shows != null )
                {
                    return View( shows );
                }
            }
            return View( );
        }
        public ActionResult Thriller()
        {
            using ( MediaRepo mediaRepo = new MediaRepo( ) )
            {
                var thrillers = ( from m in mediaRepo.GetMediaByCategoryID( 6 )
                                 orderby m.title descending
                                 select m );
                if ( thrillers != null )
                {
                    return View( thrillers );
                }
            }
            return View( );
        }
        public ActionResult Other()
        {
            using (MediaRepo mediaRepo = new MediaRepo())
            {
                var others = (from m in mediaRepo.GetMediaByCategoryID(15)
                                orderby m.title descending
                                select m);
                if (others != null)
                {
                    return View(others);
                }
            }
            return View();
        }
	}
}