using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
	public class AlphabetizedTextsViewmodel
    {
        public IEnumerable<Media> allMedia {get; set;}

		public int pageCount { get; set; }
    }
}