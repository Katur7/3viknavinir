namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TranslationLines
    {
        public int ID { get; set; }

        public int chapterNumber { get; set; }

        public string startTime { get; set; }

        public string endTime { get; set; }

        public string subtitle { get; set; }

        public bool isEditing { get; set; }

        public DateTime dateOfSubmission { get; set; }

        public int translationID { get; set; }

        public virtual Translation Translation { get; set; }
    }
}
