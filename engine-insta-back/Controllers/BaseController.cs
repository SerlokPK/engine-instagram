using Common.Constants;
using Common.Helpers;
using engine_insta_back.Filters;
using Models.Account;
using System.Security.Authentication;
using System.Security.Claims;
using System.Web.Http;

namespace engine_insta_back.Controllers
{
    [JwtAuthenticationFilter]
    [ValidationActionFilter]
    public class BaseController : ApiController
    {
        internal IdentityUser GetUser()
        {
            var claimsIdentity = (ClaimsIdentity)this.RequestContext.Principal.Identity;
            if (claimsIdentity == null)
            {
                throw new AuthenticationException(Localization.Base_NotLoggedIn);
            }
            var user = JwtHelper.GetUser(claimsIdentity.Claims);

            return user;
        }
    }
}
