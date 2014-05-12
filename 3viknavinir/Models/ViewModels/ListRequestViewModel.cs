using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models.ViewModels
{
	public class ListRequestViewModel
	{
		public int Id { get; set; }
		public string title { get; set; }
		public int yearOfRelease { get; set; }
		public string IMDBId { get; set; }
		public string requestByName { get; set; }
		public string requestById { get; set; }
	}
}