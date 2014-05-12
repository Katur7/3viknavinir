namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Upvote
    {
        public int Id { get; set; }

        public string userID { get; set; }

        public int? translationID { get; set; }

        public int? requestID { get; set; }

        public int? discussionID { get; set; }

        public virtual Discussion Discussion { get; set; }

        public virtual Requests Requests { get; set; }

        public virtual Translation Translation { get; set; }
    }
}
