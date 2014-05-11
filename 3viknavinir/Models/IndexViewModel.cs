using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
	public class IndexViewModel
	{
		public IEnumerable<Media> recentMedia { get; set; }

		public IEnumerable<Media> popularMedia { get; set; }

		public IEnumerable<Requests> popularRequests { get; set; }
	}
}