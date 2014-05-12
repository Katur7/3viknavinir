using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _3viknavinir.Models
{
    // Steinunn
    public class TranslationViewModel
    {
        [Required( ErrorMessage = "Slá verður inn nafn myndefnis" )]
        [DataType(DataType.Text)]
        [Display( Name = "Nafn Kvikmyndar" )]
        public string title { get; set; }

        [Required( ErrorMessage = "Slá verður inn ár sem  mynd var gefin út" )]
        [Display( Name = "Ártal" )]
        public uint yearOfRelease { get; set; }

        [Display( Name = "IMDB ID" )]
        public string imdbID { get; set; }
        [Display( Name = "Lýsing")]
        public string description { get; set; }
    }
}