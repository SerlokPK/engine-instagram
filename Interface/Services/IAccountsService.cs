using Models.Users;

namespace Interface.Services
{
    public interface IAccountsService
    {
        UserAuth Login(string email, string password);
        void Register(string email, string username, string password, string confirmPassword);
        void ActivateAccount(string userKey);
    }
}
