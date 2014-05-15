using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models.ViewModels
{
	public class TranslatedTextViewModel
	{
		public IEnumerable<TranslationLines> textToTranslate { get; set; }
		public bool isFinished { get; set; }
		public int mediaID { get; set; }
		public int counter { get; set; }
	}
}