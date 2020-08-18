using Interface.Services;
using Models.Account.ApiModels;
using System.Web.Http;

namespace engine_insta_back.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        private readonly IAccountsService _accountsService;

        public AccountController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginModel model)
        {
            var userAuth = _accountsService.Login(model.Email, model.Password);

            return Ok(userAuth);
        }
    }
}
