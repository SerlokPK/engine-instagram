using engine_insta_back.Filters;
using Interface.Services;
using Models.Account.ApiModels;
using System.Web.Http;

namespace engine_insta_back.Controllers
{
    [RoutePrefix("api/account")]
    [ValidationActionFilter]
    public class AccountController : ApiController
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

        [HttpPost]
        [Route("register")]
        public void Register(RegistrationModel model)
        {
            _accountsService.Register(model.Email, model.Username, model.Password, model.ConfirmPassword);
        }

        [HttpPatch]
        [Route("activate/{userKey}")]
        public void ActivateAccount(string userKey)
        {
            _accountsService.ActivateAccount(userKey);
        }
    }
}
