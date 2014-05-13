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
			if (id.HasValue)
			{
				int realid = id.Value;
				using (DiscussionRepo discussionRepo = new DiscussionRepo())
				{
					using( MediaRepo mediaRepo = new MediaRepo())
					{
						DiscussionViewModel viewModel = new DiscussionViewModel();

						if (discussionRepo.IsExistingID(realid))
						{
							var allDiscussions = (from d in discussionRepo.GetCommentByMediaID(realid)
												  orderby d.dateAdded descending
												  select d);
							viewModel.discussions = allDiscussions;
							viewModel.media = mediaRepo.GetMediaByID(realid);
							viewModel.isEmpty = false;

							using( UserRepo userRepo = new UserRepo())
							{
								viewModel.userName = userRepo.GetUserNameByID()
							}

							return View(viewModel);
						}
						else
						{
							viewModel.isEmpty = true;
							return View(viewModel);
						}
					}
                }
            }
			return HttpNotFound();
        }
	}
}