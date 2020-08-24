using Models.User;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IUsersService
    {
        List<string> SearchUsers(string username);
    }
}
