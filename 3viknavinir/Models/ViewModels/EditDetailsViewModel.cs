using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models.ViewModels
{
	public class EditDetailsViewModel
	{
		public int ID { get; set; }
		public string title { get; set; }

		public int year { get; set; }

		public string description { get; set; }

		public IEnumerable<Category> categories { get; set; }

		public string posterPath { get; set; }
	}
}