using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static UserStatus Pending = new UserStatus("P", "Pending");

        public static UserStatus Active = new UserStatus("A", "Active");

        public static UserStatus Blocked = new UserStatus("B", "Blocked");

        public static UserStatus Deleted = new UserStatus("D", "Deleted");

        public static UserStatus Unknown = new UserStatus("X", "Unknown");

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
