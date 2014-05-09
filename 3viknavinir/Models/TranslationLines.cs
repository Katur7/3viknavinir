namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TranslationLines
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int chapterNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string startTime { get; set; }

        [Required]
        [StringLength(50)]
        public string endTime { get; set; }

        [Required]
        public string subtitle { get; set; }

        public bool isEditing { get; set; }

        public DateTime dateOfSubmission { get; set; }

        public int translationID { get; set; }

        public virtual Translation Translation { get; set; }
    }
}
