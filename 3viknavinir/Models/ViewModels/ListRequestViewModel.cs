using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models.ViewModels
{
	public class ListRequestViewModel
	{
		public List<ListRequestViewModel> allRequests { get; set; }
		public int Id { get; set; }
		public string title { get; set; }
		public int yearOfRelease { get; set; }
		public string IMDBId { get; set; }
		public string requestByName { get; set; }
		public string requestById { get; set; }
		public int upvotes { get; set; }
		public int pageCount { get; set; }
	}
}