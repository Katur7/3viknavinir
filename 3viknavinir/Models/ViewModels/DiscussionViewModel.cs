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
        public string comment { get; set; }
        public string userID { get; set; }
        public DateTime dateAdded { get; set; }
        public int mediaID { get; set; }
    }
}