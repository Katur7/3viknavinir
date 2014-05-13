using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Web.Mvc;

namespace _3viknavinir.Models
{
	public class MediaDetailsViewModel
	{
		public Media media { get; set; }
		public Translation translation { get; set; }
		public string userName { get; set; }

        [Required( ErrorMessage = "Slá verður inn nafn myndefnis" )]
        [DataType( DataType.Text )]
        [Display( Name = "Nafn Kvikmyndar" )]
        public string title { get; set; }

        [Required( ErrorMessage = "Slá verður inn ár sem  mynd var gefin út" )]
        [Display( Name = "Ártal" )]
        public int yearOfRelease { get; set; }

        [Display( Name = "IMDB ID" )]
        public string imdbID { get; set; }
        [Display( Name = "Lýsing" )]
        public string description { get; set; }
		public int category { get; set; }
		public List<SelectListItem> categories { get; set; }
        public Image posterPath { get; set; }
	}
}