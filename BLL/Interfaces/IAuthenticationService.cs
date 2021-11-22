using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<JwtSecurityToken> Login(string email, string password);
        public void Logout(string token);
        public bool IsBlacklisted(string token);
        public DateTime? GetExpiryTime();
    }
}
