using Models.User;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IUsersService
    {
        List<string> SearchUsers(string username);
        Models.User.User GetUser(int userId);
    }
}
