using _3viknavinir.Repo;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Controllers
{
    public class DiscussionController : Controller
    {
        //
        // GET: /Discussion/
        public ActionResult Index(int? id)
        {
            if(id.HasValue)
            {
                int realid = id.Value;
            
                using (DiscussionRepo discussionRepo = new DiscussionRepo()) 
                {
                    IEnumerable<Discussion> discussion = (from d in discussionRepo.GetCommentByMediaID(realid)
                                                          select d);
                }
            }
            return View( );
        }
	}
}