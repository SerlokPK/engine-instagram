using Common;
using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Interface.Repositories;
using Interface.Services;
using Models.Account.ApiModels;
using Models.Users;

namespace Service.Account
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;
        public AccountsService(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }
        public UserAuth Login(LoginModel model)
        {
            var user = _accountsRepository.Login(model.Email, model.Password);
            if (user != null && user.User.Status == UserStatus.Active.Status)
            {
                user.Token = JwtHelper.GenerateToken(user.User.UserId, user.User.Email, AppSettings.TokenExpirationMinutes);

                return user;
            }
            throw new UnauthorizedException(Localization.Login_WrongCredentials);
        }
    }
}
