using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models.ViewModels
{
	public class MediaViewModel
	{
		public int ID { get; set; }

		public string title { get; set; }

		public int yearOfRelease { get; set; }

		public string description { get; set; }

		public string posterPath { get; set; }

		public string imdbID { get; set; }

		public int categoryID { get; set; }
		public int upvotes { get; set; }
	}
}