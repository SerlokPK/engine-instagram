namespace Models.ModelAttributes
{
    public class Localization
    {
        #region Account

        public const string Login_EmailRequired = "Email is required";
        public const string Login_EmailFormatNotValid = "Email format not valid";
        public const string Login_LongPassword = "Password too long";

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
