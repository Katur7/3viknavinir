namespace _3viknavinir.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Language
    {
        public int ID { get; set; }

        public string name { get; set; }

        public virtual ICollection<Translation> Translation { get; set; }
    }
}
