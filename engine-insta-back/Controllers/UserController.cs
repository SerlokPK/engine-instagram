using System.Collections.Generic;
using System.Web.Http;

namespace engine_insta_back.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : BaseController
    {
        // GET: api/User
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("{username}")]
        public string Search(string username)
        {
            return "value";
        }
    }
}
