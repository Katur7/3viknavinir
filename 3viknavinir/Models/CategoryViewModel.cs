using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class CategoryViewModel
    {
        
    }

    public class DocumentaryViewModel
    {
        public IEnumerable<Category> documentaries { get; set; }
    }
}