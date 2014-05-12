namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Media
    {
        public int ID { get; set; }

        public string title { get; set; }

        public int yearOfRelease { get; set; }

        public string description { get; set; }

        public string posterPath { get; set; }

		public string imdbID { get; set; }

        public int categoryID { get; set; }

		public virtual Category Category { get; set; }
    }
}
