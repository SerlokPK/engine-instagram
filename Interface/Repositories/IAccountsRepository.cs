using Models.Account;
using Models.Users;

namespace Interface.Repositories
{
    public interface IAccountsRepository
    {
        UserAuth Login(string email, string password);
        RegisteredUser Register(string email, string username, string password, string confirmPassword);
    }
}
