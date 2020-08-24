using Interface.Repositories;
using Interface.Services;
using Models.User;
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
        public List<UserSearched> SearchUsers(string username)
        {
            return _usersRepository.SearchUsers(username);
        }
    }
}
