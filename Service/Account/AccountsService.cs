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
        private readonly IAdminsRepository _adminsRepository;
        public AccountsService(IAccountsRepository accountsRepository, IAdminsRepository adminsRepository)
        {
            _accountsRepository = accountsRepository;
            _adminsRepository = adminsRepository;
        }
        public UserAuth Login(string email, string password)
        {
            _adminsRepository.AssureTestUserExist(email, password);
            var user = _accountsRepository.Login(email, password);
            if (user != null && user.User.Status == UserStatus.Active.Status)
            {
                user.Token = JwtHelper.GenerateToken(user.User.UserId, user.User.Email, AppSettings.TokenExpirationMinutes);

                return user;
            }
            throw new UnauthorizedException(Localization.Login_WrongCredentials);
        }
    }
}
