namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public int ID { get; set; }

        public string name { get; set; }

        public string posterPath { get; set; }
    }
}
