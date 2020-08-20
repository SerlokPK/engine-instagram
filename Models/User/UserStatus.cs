using Models.ModelAttributes;

namespace Models.Users
{
    public class UserStatus
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public UserStatus()
        {

        }

        public UserStatus(string status, string name)
        {
            Status = status;
            Name = name;
        }

        public static UserStatus Pending = new UserStatus("P", Localization.Users_PendingStatus);

        public static UserStatus Active = new UserStatus("A", Localization.Users_ActiveStatus);

        public static UserStatus Blocked = new UserStatus("B", Localization.Users_BlockedStatus);

        public static UserStatus Deleted = new UserStatus("D", Localization.Users_DeletedStatus);

        public static UserStatus Unknown = new UserStatus("X", Localization.Users_Unknown);

        public static UserStatus GetStatus(string status)
        {
            switch (status)
            {
                case "P":
                    return Pending;
                case "A":
                    return Active;
                case "B":
                    return Blocked;
                case "D":
                    return Deleted;
                default:
                    return Unknown;
            }
        }
    }
}
