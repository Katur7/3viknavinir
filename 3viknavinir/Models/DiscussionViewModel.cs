namespace _3viknavinir.Models
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;

    public class DiscussionViewModel
    {
        public IEnumerable<Discussion> discussions { get; set; }
        public Media media{ get; set; }

    }
}