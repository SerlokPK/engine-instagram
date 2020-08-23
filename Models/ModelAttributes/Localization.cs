namespace Models.ModelAttributes
{
    public class Localization
    {
        #region Account

        public const string Login_EmailRequired = "Email is required";
        public const string Login_EmailFormatNotValid = "Email format not valid";
        public const string Login_LongPassword = "Password can't be over 50 characters";
        public const string Login_PasswordRequired = "Password required";

        public const string Register_UsernameRequired = "Username required";
        public const string Register_LongUsername = "Username can't be over 50 characters";
        public const string Register_PasswordsArentSame = "Password and confirm password must be identical";
        public const string Register_NoWhitespace = "Username can't have whitespace";
        public const string Register_ValidPassword = "Password must have 1 uppercase, 1 lowercase, 1 digit and 1 special character";

        public const string ResetPassword_ResetKeyRequired = "Reset key is required";

        #endregion

        #region Users

        public const string Users_ActiveStatus = "Active";
        public const string Users_PendingStatus = "Pending";
        public const string Users_BlockedStatus = "Blocked";
        public const string Users_DeletedStatus = "Deleted";
        public const string Users_Unknown = "Unknown";

        #endregion
    }
}
