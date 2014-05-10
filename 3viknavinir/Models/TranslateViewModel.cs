using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3viknavinir.Models
{
    public class TranslateViewModel
    {
        [Required(ErrorMessage = "Slá verður inn nafn myndefnis")]
        [Display(Name = "Nafn Kvikmyndar")]
        public string movieName { get; set; }

        [Required(ErrorMessage = "Slá verður inn ár sem  mynd var gefin út")]
        [Display(Name = "Year of Release")]
        public uint yearOfRelease { get; set; }
    }
}