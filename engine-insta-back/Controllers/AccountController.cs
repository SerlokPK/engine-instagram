using Common.Constants;
using engine_insta_back.Filters;
using Interface.Services;
using Models.Account.ApiModels;
using System;
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
        public IHttpActionResult Register(RegistrationModel model)
        {
            var user =_accountsService.Register(model.Email, model.Username, model.Password, model.ConfirmPassword, Localization.Base_EnLanguageSign);

            if(user == null)
            {
                return Ok();
            }
            
            return Created(new Uri(Request.RequestUri.AbsoluteUri), user);
        }

        [HttpPatch]
        [Route("activate/{userKey}")]
        public void ActivateAccount(string userKey)
        {
            _accountsService.ActivateAccount(userKey, Localization.Base_EnLanguageSign);
        }

        [HttpPatch]
        [Route("forgotpassword")]
        public void ForgotPassword([FromBody] string email)
        {
            _accountsService.ForgotPassword(email, Localization.Base_EnLanguageSign);
        }

        [HttpPatch]
        [Route("resetpassword")]
        public void ResetPassword(ResetPasswordModel model)
        {
            _accountsService.ResetPassword(model.Password, model.ResetKey, Localization.Base_EnLanguageSign);
        }
    }
}
