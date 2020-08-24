using Models.Account;
using Models.Users;

namespace Interface.Services
{
    public interface IAccountsService
    {
        UserAuth Login(string email, string password);
        User Register(string email, string username, string password, string confirmPassword, string languageSign);
        void ActivateAccount(string userKey, string languageSign);
        void ForgotPassword(string email, string languageSign);
        void ResetPassword(string password, string resetKey, string languageSign);
    }
}
