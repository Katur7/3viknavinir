using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class SearchMediaViewModel
    {
        [Required(ErrorMessage = "Vinsamlegast sláðu inn leitarstreng.")]
        [Display(Name = "leita")]
        public IEnumerable<Media> searchedMedia { get; set; }
    }
}