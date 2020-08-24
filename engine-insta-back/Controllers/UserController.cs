using Interface.Services;
using System.Web.Http;

namespace engine_insta_back.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseController
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        [Route("{username}")]
        public IHttpActionResult Search(string username)
        {
            var users = _usersService.SearchUsers(username);

            return Ok(users);
        }
    }
}
