using _3viknavinir.Repo;
using _3viknavinir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _3viknavinir.Models.ViewModels;

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

						if (mediaRepo.IsExistingID(realid))
						{
							if(discussionRepo.IsExistingID(realid))
							{
								var allDiscussions = (from d in discussionRepo.GetCommentByMediaID(realid)
													  orderby d.dateAdded descending
													  select d);
								using (UserRepo userRepo = new UserRepo())
								{
									viewModel.discussions = new List<DiscussionUserViewModel>();
									foreach (var item in allDiscussions)
									{
										DiscussionUserViewModel newDiscussionUserViewModel = new DiscussionUserViewModel();
										newDiscussionUserViewModel.userName = userRepo.GetUserNameByID(item.userID);
										newDiscussionUserViewModel.discussion = item;

										viewModel.discussions.Add(newDiscussionUserViewModel);
									}
								}

								viewModel.media = mediaRepo.GetMediaByID(realid);

								return View(viewModel);
							} else
							{
								viewModel.isEmpty = true;
								return View(viewModel);
							}
						} else
						{
							return HttpNotFound();
						}
					}
                }
            }
			return HttpNotFound();
        }
	}
}