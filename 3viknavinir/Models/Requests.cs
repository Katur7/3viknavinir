namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Requests
    {
		public Requests()
        {
            Upvote = new HashSet<Upvote>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime dateOfRequest { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        public int yearOfRelease { get; set; }

        [StringLength(50)]
        public string imdbID { get; set; }

        [Required]
        [StringLength(128)]
        public string userID { get; set; }

        public virtual ICollection<Upvote> Upvote { get; set; }
    }
}
