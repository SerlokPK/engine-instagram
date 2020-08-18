using Models.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Models.Account.ApiModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = Localization.Login_EmailRequired)]
        [RegularExpression(Regex.Email, ErrorMessage = Localization.Login_EmailFormatNotValid)]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = Localization.Login_LongPassword)]
        public string Password { get; set; }
    }
}
