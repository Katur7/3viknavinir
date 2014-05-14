namespace _3viknavinir.Models
{
	using _3viknavinir.Models.ViewModels;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

    public class DiscussionViewModel
    {
        public List<DiscussionUserViewModel> discussions { get; set; }
		public Media media{ get; set; }

		public bool isEmpty { get; set; }
    }
}