using Models.Users;

namespace Interface.Services
{
    public interface IAccountsService
    {
        UserAuth Login(string email, string password);
    }
}
