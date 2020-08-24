using Models.User;
using System.Collections.Generic;

namespace Interface.Repositories
{
    public interface IUsersRepository
    {
        List<string> SearchUsers(string username);
        User GetUser(int userId);
    }
}
