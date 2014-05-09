﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _3viknavinir.Models
{
    public class RequestViewModels
    {
        
    }
    // Steinunn
    public class NewRequestViewModel
    {
        [Required( ErrorMessage = "Slá verður inn nafn myndefnis" )]
        [Display( Name = "Nafn Kvikmyndar" )]
        public string movieName { get; set; }

        [Required( ErrorMessage = "Slá verður inn ár sem  mynd var gefin út" )]
        [Display( Name = "Ártal" )]
        public int yearOfRelease { get; set; }

        [Display( Name = "IMDB ID" )]
        public string imdbID { get; set; }
    }
}