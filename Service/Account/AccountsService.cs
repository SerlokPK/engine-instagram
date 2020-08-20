using Common;
using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Interface.Repositories;
using Interface.Services;
using Models.Users;

namespace Service.Account
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;
        public AccountsService(IAccountsRepository accountsRepository, IAdminsRepository adminsRepository)
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
            throw new UnauthorizedException(Localization.Login_WrongCredentials);
        }

        public void Register(string email, string username, string password, string confirmPassword)
        {
            var registeredUser = _accountsRepository.Register(email, username, password, confirmPassword);
            if (registeredUser != null)
            {
                var link = $"{AppSettings.WebsiteUrl}/account/activate?userKey={registeredUser.UserKey}";
                //_mailService.(Localization.Register_MailSubject, webSiteUserData.User.LanguageSign, model.Email, $"{model.FirstName} {model.LastName}", link);

                return;
            }

            if (!string.IsNullOrEmpty(registeredUser.ErrorMessage))
            {
                throw new ConflictException(registeredUser.ErrorMessage);
            }
        }
    }
}
