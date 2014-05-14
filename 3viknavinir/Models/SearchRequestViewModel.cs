using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class SearchRequestViewModel
    {
		public IEnumerable<Requests> searchedRequests { get; set; }

    }
}