using Common.Helpers;
using engine_insta_back.Helpers;
using Microsoft.IdentityModel.Tokens;
using Models.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace engine_insta_back.Filters
{
    public class JwtAuthenticationFilter : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            if (authorization == null || authorization.Scheme != "Bearer" || string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }

            var token = authorization.Parameter;
            var principal = await AuthenticateJwtToken(token);

            if (principal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
            }
            else
            {
                context.Principal = principal;
            }
        }

        private Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            var tokenObj = GetTokenProperties(token);

            if (tokenObj != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, tokenObj.Email),
                    //new Claim(JwtHelper.IdClaim, tokenObj.UserId)
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        private Token GetTokenProperties(string token)
        {
            var tokenObj = new Token();
            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null || !identity.IsAuthenticated)
            {
                return null;
            }

            var emailClaim = identity.FindFirst(ClaimTypes.Name);
            var idClaim = identity.FindFirst(JwtHelper.IdClaim);
            var email = emailClaim?.Value;
            var id = idClaim?.Value;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(id))
            {
                return null;
            }
            tokenObj.UserId = id;
            tokenObj.Email = email;

            return tokenObj;
        }

        private static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                if (!(tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken))
                {
                    return null;
                }

                var symmetricKey = Convert.FromBase64String(AppSettings.JwtKey);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }
            catch (Exception)
            {
                // TODO logger
                return null;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}