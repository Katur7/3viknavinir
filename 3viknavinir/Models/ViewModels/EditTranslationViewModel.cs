using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class EditTranslationViewModel
    {
        public IEnumerable<TranslationLines> textToTranslate { get; set; }
        public IEnumerable<TranslationLines> translatedText { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public bool isFinished { get; set; }
        public int mediaID { get; set; }
		public int counter { get; set; }
    }
}