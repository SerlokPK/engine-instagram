using Models.User;
using System.Collections.Generic;

namespace Interface.Repositories
{
    public interface IUsersRepository
    {
        List<UserSearched> SearchUsers(string username);
    }
}
