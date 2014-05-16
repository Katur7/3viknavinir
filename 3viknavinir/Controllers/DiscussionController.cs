using _3viknavinir;
using _3viknavinir.Models;
using _3viknavinir.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using _3viknavinir.Models.ViewModels;

namespace _3viknavinir.Controllers
{
    public class DiscussionController : Controller
    {
        //
        // GET: /Discussion/
        [HttpGet]
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
							viewModel.media = mediaRepo.GetMediaByID(realid);

							if (discussionRepo.IsExistingID(realid))
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
                                return View(viewModel);
							} 
                            else
							{
								viewModel.isEmpty = true;
								return View(viewModel);
							}
						} 
                        else
						{
							return RedirectToAction("Error404", "Home");
						}
					}
                }
            }
			return RedirectToAction("Error404", "Home");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Translation(DiscussionViewModel model)
        {
            using (DiscussionRepo discussionRepo = new DiscussionRepo())
            {
                if (ModelState.IsValid)
                {
                    var newComment = new Discussion();

                    newComment.comment = model.comment;
                    newComment.dateAdded = DateTime.Now;
                    newComment.userID = User.Identity.GetUserId();
                    newComment.mediaID = model.media.ID;

                    discussionRepo.AddComment(newComment);
                    
                    return RedirectToAction("Translation", "Discussion");
                }
            }
            return View();
        }
	}
}