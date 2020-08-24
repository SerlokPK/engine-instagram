namespace Models.Account
{
    public class RegisteredUser
    {
        public Models.User.User User { get; set; }
        public string UserKey { get; set; }
        public string ErrorMessage { get; set; }
    }
}
