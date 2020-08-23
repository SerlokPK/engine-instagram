using System;

namespace Models.Account
{
    public class UserReset
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string ResetKey { get; set; }
        public DateTime? ResetKeyTime { get; set; }
    }
}
