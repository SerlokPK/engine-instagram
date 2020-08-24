using Interface.Repositories;
using Models.User;
using System.Collections.Generic;
using System.Linq;

namespace Repository.User
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public List<UserSearched> SearchUsers(string username)
        {
            using (var context = GetContext())
            {
                return context.Users.Where(u => u.Username.ToLower().StartsWith(username.ToLower())).Select(x => new UserSearched
                {
                    UserId = x.UserId,
                    Username = x.Username
                }).ToList();
            }
        }
    }
}
