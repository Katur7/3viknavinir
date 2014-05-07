using System.ComponentModel.DataAnnotations;

namespace _3viknavinir.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
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
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required]
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
        [Required( ErrorMessage = "Vinsamlegast fylltu út í þennan reit." )]  
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required( ErrorMessage = "Vinsamlegast fylltu út í þennan reit." )]  
        [StringLength(100, ErrorMessage = "Lykilorðið verður að vera að minnsta kosti 6 stafir", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfestu lykilorð")]
        [Compare("Password", ErrorMessage = "Lykilorðin passa ekki saman")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage="Vinsamlegast fylltu út í þennan reit.")]    
        [DataType( DataType.Text )]
        [Display( Name = "Fornafn" )]
        public string FirstName { get; set; }

        [Required( ErrorMessage = "Vinsamlegast fylltu út í þennan reit." )] 
        [DataType( DataType.Text )]
        [Display( Name = "Eftirnafn" )]
        public string LastName { get; set; }

        [Required( ErrorMessage = "Vinsamlegast fylltu út í þennan reit." )] 
        [DataType(DataType.EmailAddress)]
        [Display( Name = "Tölvupóstfang" )]
        public string Email { get; set; }

        [Required( ErrorMessage = "Vinsamlegast fylltu út í þennan reit." )] 
        [Display( Name = "Fæðingarár" )]
        public string BirthYear { get; set; }
    }
}
