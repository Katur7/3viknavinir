namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Upvote")]
    public partial class Upvote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int userID { get; set; }

        public int? translationID { get; set; }

        public int? requestID { get; set; }

        public int? discussionID { get; set; }

        public virtual Discussion Discussion { get; set; }

        public virtual Requests Requests { get; set; }

        public virtual Translation Translation { get; set; }
    }
}
