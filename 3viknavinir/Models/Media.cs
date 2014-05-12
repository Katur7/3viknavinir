namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Media
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        public uint yearOfRelease { get; set; }

        public string description { get; set; }

        [StringLength(50)]
        public string posterPath { get; set; }

		public string imdbID { get; set; }

        public int categoryID { get; set; }

		public virtual Category Category { get; set; }
    }
}
