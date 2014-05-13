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
        public ActionResult Translation(int? id)
        {
			using (DiscussionRepo discussionRepo = new DiscussionRepo())
			{
				if (id.HasValue)
			    {
                    int realid = id.Value;
                    if (discussionRepo.IsExistingID(realid))
                    {
						DiscussionViewModel viewModel = new DiscussionViewModel();

						IEnumerable<Discussion> allDiscussions = (from d in discussionRepo.GetCommentByMediaID(realid)
																  orderby d.dateAdded descending
																  select d);
						viewModel.discussions = allDiscussions;
                        if (allDiscussions != null)
                        {
                            return View(viewModel);
                        }
                        else
                        {
                            return View( );
                        }
                        //IEnumerable<Discussion> discussion = (from d in discussionRepo.GetCommentByMediaID(realid)
                        //                                      select d).ToList();
                    }
					else
					{
						return View( );
					}
                }
				return View();
            }
        }
	}
}