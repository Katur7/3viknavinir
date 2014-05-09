namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Translation")]
    public partial class Translation
    {
        public Translation()
        {
            TranslationLines = new HashSet<TranslationLines>();
            Upvote = new HashSet<Upvote>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public bool finished { get; set; }

        public int mediaID { get; set; }

        public int languageID { get; set; }

        public int userID { get; set; }

        public virtual Language Language { get; set; }

        public virtual ICollection<TranslationLines> TranslationLines { get; set; }

        public virtual ICollection<Upvote> Upvote { get; set; }
    }
}
