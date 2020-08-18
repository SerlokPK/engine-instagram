using Models.Users;

namespace Interface.Repositories
{
    public interface IAccountsRepository
    {
        UserAuth Login(string email, string password);
    }
}
