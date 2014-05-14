using _3viknavinir.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
	public class AlphabetizedTextsViewmodel
    {
        public List<MediaUpvoteViewModel> allMedia {get; set;}
		public int pageCount { get; set; }
    }
}