using Common;
using Common.Helpers;
using Interface.Repositories;
using Interface.Services;
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
        public UserAuth Login(string email, string password)
        {
            var user = _accountsRepository.Login(email, password);
            if (user != null && user.User.Status == UserStatus.Active.Status)
            {
                user.Token = JwtHelper.GenerateToken(user.User.UserId, user.User.Email, AppSettings.TokenExpirationMinutes);

                return user;
            }
            //throw new UnauthorizedException(_dictionaryService.GetLocalization(languageSign, Constants.Localization.WrongCredentials));
        }
    }
}
