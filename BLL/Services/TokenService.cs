using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TokenService : ITokenService
    {
        private IMemoryCache _cache;
        private const string TokensKey = "token_";
        private const int ExpirationInMinutes = 30;

        private UserManager<User> _userManager;


        public TokenService(IMemoryCache cache, UserManager<User> userManager)
        {
            _cache = cache;
            _userManager = userManager;

        }

        public bool IsBlacklisted(string token) 
        {
            return _cache.Get(TokensKey + token) != null;
        }

        public async Task<JwtSecurityToken> Login(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email.Normalize());
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Settings["JWT:Secret"].ToString()));

                var token = new JwtSecurityToken(
                    issuer: AppSettings.Settings["JWT:ValidIssuer"].ToString(),
                    audience: AppSettings.Settings["JWT:ValidAudience"].ToString(),
                    expires: GetExpiryTime(),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return token;
            }

            return null;
        }

        public void Logout(string token)
        {
            _cache.Set(TokensKey + token, 1, TimeSpan.FromMinutes(ExpirationInMinutes + 1));
        }

        public DateTime? GetExpiryTime()
        {
            return DateTime.Now.AddMinutes(ExpirationInMinutes);
        }


    }
}
