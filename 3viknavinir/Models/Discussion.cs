namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Discussion
    {
        public int ID { get; set; }

        public string comment { get; set; }

        public DateTime dateAdded { get; set; }

        public string userID { get; set; }

        public int mediaID { get; set; }

        public virtual ICollection<Upvote> Upvote { get; set; }
    }
}
