using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
	public class IndexViewModel
	{
		public IEnumerable<Media> recentMedia { get; set; }

		public IEnumerable<Requests> recentRequests { get; set; }
	}
}