using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class Request
    {
        public int ID { get; set; }
        public DateTime dateOfRequest { get; set; }
        public string title { get; set; }
        public int yearOfRelease { get; set; }
        public string imdbId { get; set; }
        public string userID { get; set; }


    }
}