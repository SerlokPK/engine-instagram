using Models.Account.ApiModels;
using Models.Users;

namespace Interface.Services
{
    public interface IAccountsService
    {
        UserAuth Login(LoginModel model);
    }
}
