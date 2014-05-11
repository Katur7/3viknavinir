namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Discussion
    {
        public Discussion()
        {
            Upvote = new HashSet<Upvote>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string comment { get; set; }

        public DateTime dateAdded { get; set; }

        public string userID { get; set; }

        public int mediaID { get; set; }

        public virtual ICollection<Upvote> Upvote { get; set; }
    }
}
