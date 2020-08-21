using Models.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Models.Account.ApiModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = Localization.Login_EmailRequired)]
        [RegularExpression(Regex.Email, ErrorMessage = Localization.Login_EmailFormatNotValid)]
        public string Email { get; set; }

        [Required(ErrorMessage = Localization.Register_UsernameRequired)]
        [RegularExpression(Regex.NoWthispace, ErrorMessage = Localization.Register_NoWhitespace)]
        [StringLength(50, ErrorMessage = Localization.Register_LongUsername)]
        public string Username { get; set; }

        [Required(ErrorMessage = Localization.Login_PasswordRequired)]
        [StringLength(20, ErrorMessage = Localization.Login_LongPassword)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = Localization.Register_PasswordsArentSame)]
        public string ConfirmPassword { get; set; }
    }
}
