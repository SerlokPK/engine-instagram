using Models.Users;

namespace Models.Account
{
    public class RegisteredUser
    {
        public User User { get; set; }
        public string UserKey { get; set; }
        public string ErrorMessage { get; set; }
    }
}
