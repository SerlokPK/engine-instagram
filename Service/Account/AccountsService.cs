using Common;
using Common.Constants;
using Common.Exceptions;
using Common.Helpers;
using Interface.Repositories;
using Interface.Services;
using Models.Account;
using Models.Users;

namespace Service.Account
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IMailService _mailService;
        public AccountsService(IAccountsRepository accountsRepository, IMailService mailService)
        {
            _accountsRepository = accountsRepository;
            _mailService = mailService;
        }

        public void ActivateAccount(string userKey, string languageSign)
        {
            if (!string.IsNullOrEmpty(userKey))
            {
                var user = _accountsRepository.ActivateAccount(userKey);
                if (user != null)
                {
                    var link = $"{AppSettings.WebsiteUrl}/account/login";
                    _mailService.AccountActivatedSendMail(languageSign, user.Email, user.Username, link);

                    return;
                }
                throw new UnauthorizedException(Localization.Activate_InvalidLink);
            }
        }

        public void ForgotPassword(string email, string languageSign)
        {
            var user = _accountsRepository.ForgotPassword(email);
            if (user != null)
            {
                var link = $"{AppSettings.WebsiteUrl}/account/resetpassword/{user.ResetKey}";
                _mailService.ResetPasswordSendMail(languageSign, user.Email, user.Username, link);
            }
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

        public void Register(string email, string username, string password, string confirmPassword, string languageSign)
        {
            var registeredUser = _accountsRepository.Register(email, username, password, confirmPassword);
            if (registeredUser != null)
            {
                if (string.IsNullOrEmpty(registeredUser.ErrorMessage))
                {
                    var link = $"{AppSettings.WebsiteUrl}/account/activate/{registeredUser.UserKey}";
                    _mailService.RegisteredUserSendMail(languageSign, email, username, link);

                    return;
                }
                throw new ConflictException(registeredUser.ErrorMessage);
            }
        }

        public void ResetPassword(string password, string resetKey, string languageSign)
        {
            var user = _accountsRepository.ResetPassword(password, resetKey);
            if (user != null)
            {
                var link = $"{AppSettings.WebsiteUrl}/account/login";
                _mailService.ResetPasswordDoneSendMail(languageSign, user.Email, user.Username, link);
            }
        }
    }
}
