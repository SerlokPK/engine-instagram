using Models.User;
using System.Collections.Generic;

namespace Interface.Services
{
    public interface IUsersService
    {
        List<UserSearched> SearchUsers(string username);
    }
}
