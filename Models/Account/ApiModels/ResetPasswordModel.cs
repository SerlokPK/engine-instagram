using Models.ModelAttributes;
using System.ComponentModel.DataAnnotations;

namespace Models.Account.ApiModels
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = Localization.ResetPassword_ResetKeyRequired)]
        public string ResetKey { get; set; }

        [Required(ErrorMessage = Localization.Login_PasswordRequired)]
        [RegularExpression(Regex.ValidPassword, ErrorMessage = Localization.Register_ValidPassword)]
        [StringLength(20, ErrorMessage = Localization.Login_LongPassword)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = Localization.Register_PasswordsArentSame)]
        public string ConfirmPassword { get; set; }
    }
}
