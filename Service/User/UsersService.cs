using Interface.Repositories;
using Interface.Services;
using System.Collections.Generic;

namespace Service.User
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Models.User.User GetUser(int userId)
        {
            return _usersRepository.GetUser(userId);
        }

        public List<string> SearchUsers(string username)
        {
            return _usersRepository.SearchUsers(username);
        }
    }
}
