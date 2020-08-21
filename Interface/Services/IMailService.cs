namespace Interface.Services
{
    public interface IMailService
    {
        bool RegisteredUserSendMail(string mailSubject, string languageSign, string email, string username, string link);
    }
}
