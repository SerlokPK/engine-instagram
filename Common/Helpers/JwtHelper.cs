using Microsoft.IdentityModel.Tokens;
using Models.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Common.Helpers
{
    public static class JwtHelper
    {
        public const string IdClaim = "id";

        public static string GenerateToken(int userId, string email, int expireMinutes)
        {
            var symmetricKey = Convert.FromBase64String(AppSettings.JwtKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(IdClaim, userId.ToString()),
                    new Claim(ClaimTypes.Name, email),
                }),

                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static IdentityUser GetUser(IEnumerable<Claim> claims)
        {
            var user = new IdentityUser();
            foreach (var claim in claims)
            {
                if (claim.Type == IdClaim)
                {
                    user.UserId = int.Parse(claim.Value);
                }
                else if (claim.Type == ClaimTypes.Name)
                {
                    user.Email = claim.Value;
                }
            }

            return user;
        }
    }
}
