using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _3viknavinir.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required( ErrorMessage = "Vinsamlegast sláðu inn notendanafn." )]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required( ErrorMessage = "Vinsamlegast sláðu inn lykilorð." )]
        [DataType(DataType.Password)]
        [Display(Name = "Núverandi lykilorð")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lykilorðið verður að vera að minnsta kosti 6 stafir", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfestu nýtt lykilorð")]
        [Compare("NewPassword", ErrorMessage = "Lykilorðin passa ekki saman")]
        public string ConfirmPassword { get; set; }
    }
    

    public class LoginViewModel
    {
        [Required( ErrorMessage = "Vinsamlegast sláðu inn notendanafn." )]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required( ErrorMessage = "Vinsamlegast sláðu inn lykilorð." )]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [Display(Name = "Muna eftir mér")]
        public bool RememberMe { get; set; }
    }

	//Erla
	public class LostPasswordViewModel
	{
		[Required]
		[Display(Name = "Tölvupóstfang")]
		public string Email { get; set; }
	}


    // Steinunn og Svava
    public class RegisterViewModel
    {
        [Required( ErrorMessage = "Vinsamlegast sláðu inn notendanafn." )]  
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required( ErrorMessage = "Vinsamlegast sláðu inn lykilorð." )]  
        [StringLength(100, ErrorMessage = "Lykilorðið verður að vera að minnsta kosti 6 stafir", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vinsamlegast staðfestu lykilorðið")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "Lykilorðin passa ekki saman")]
        [DataType(DataType.Password)]
        [Display(Name = "Staðfestu lykilorð")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage="Vinsamlegast sláðu inn fornafn.")]    
        [DataType( DataType.Text )]
        [Display( Name = "Fornafn" )]
        public string FirstName { get; set; }

        [Required( ErrorMessage = "Vinsamlegast sláðu inn eftirnafn." )] 
        [DataType( DataType.Text )]
        [Display( Name = "Eftirnafn" )]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vinsamlegast sláðu inn tölvupóstfang.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Tölvupóstfang")]
        public string Email { get; set; }

        [Required( ErrorMessage = "Vinsamlegast sláðu inn fæðingarárið þitt." )] 
        [Display( Name = "Fæðingarár" )]
        public string BirthYear { get; set; }
    }
}
