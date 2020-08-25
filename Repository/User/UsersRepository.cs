using Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repository.User
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        public Models.User.User GetUser(int userId)
        {
            using (var context = GetContext())
            {
                return context.Users.Where(u => u.UserId == userId).Select(x => new Models.User.User
                {
                    UserId = x.UserId,
                    Email = x.Email,
                    Username = x.Username,
                    Status = x.Status,
                    Description = x.Description
                }).SingleOrDefault();
            }
        }

        public List<string> SearchUsers(string username)
        {
            using (var context = GetContext())
            {
                return context.Users.Where(u => u.Username.ToLower().StartsWith(username.ToLower())).Select(x => x.Username).Take(10).ToList();
            }
        }
    }
}
