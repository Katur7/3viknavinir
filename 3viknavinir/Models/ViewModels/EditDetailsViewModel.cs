using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3viknavinir.Models.ViewModels
{
	public class EditDetailsViewModel
	{
		public int ID { get; set; }
		public string title { get; set; }

		public int year { get; set; }

		public string description { get; set; }

		public int category { get; set; }

		public string imdbId { get; set; }

		public List<SelectListItem> categories { get; set; }

		public string posterPath { get; set; }

		//public HttpPostedFileBase choosePoster { get; set; }
	}
}