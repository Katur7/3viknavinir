using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class CategoryViewModel
    {
        
    }

    public class DocumentViewModel
    {
        public IEnumerable<Category> documentaries { get; set; }
    }
    public class ComedyViewModel
    {
        public IEnumerable<Category> comedies { get; set; }
    }
}