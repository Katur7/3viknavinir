using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class EditTranslationViewModel : _3viknaContext
    {
        public IEnumerable<TranslationLines> textToTranslate { get; set; }
        public IEnumerable<TranslationLines> translatedText { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public bool isFinished { get; set; }
    }
}