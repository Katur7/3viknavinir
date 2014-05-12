namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requests
    {
        public int ID { get; set; }

        public DateTime dateOfRequest { get; set; }

        public string title { get; set; }

        public int yearOfRelease { get; set; }

        public string imdbID { get; set; }

        public string userID { get; set; }

        public virtual ICollection<Upvote> Upvote { get; set; }
    }
}
