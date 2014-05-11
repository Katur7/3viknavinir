using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
	public class IndexViewModel : _3viknaContext
	{
		public IEnumerable<Media> newestMedia;
	}
}