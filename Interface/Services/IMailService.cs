namespace Interface.Services
{
    public interface IMailService
    {
        bool RegisteredUserSendMail(string languageSign, string email, string username, string link);
        bool AccountActivatedSendMail(string languageSign, string email, string username, string link);
        bool ResetPasswordSendMail(string languageSign, string email, string username, string link);
        bool ResetPasswordDoneSendMail(string languageSign, string email, string username, string link);
    }
}
