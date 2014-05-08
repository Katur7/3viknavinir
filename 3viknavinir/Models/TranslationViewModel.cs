using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _3viknavinir.Models
{
    public class TranslationViewModel
    {
        [Required( ErrorMessage = "Slá verður inn nafn myndefnis" )]
        [Display( Name = "Nafn Kvikmyndar" )]
        public string movieName { get; set; }

        [Required( ErrorMessage = "Slá verður inn ár sem  mynd var gefin út" )]
        [Display( Name = "Year of Release" )]
        public uint yearOfRelease { get; set; }

        [Display( Name = "IMDB ID" )]
        public string imdbID { get; set; }
    }
}