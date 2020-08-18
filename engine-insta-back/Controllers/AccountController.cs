using Interface.Services;
using System.Web.Http;

namespace engine_insta_back.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountsService _accountsService;

        public AccountController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }


    }
}
