using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UI.Models;
using DAL;
using System.Collections.Generic;
using UI.Attributes;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace UI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private IAuthenticationService _tokenService;
 

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IAuthenticationService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModelRequest model)
        {
            var token = await _tokenService.Login(model.Email, model.Password);
            if (token != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost("Logout")]
        [BlacklistAuthorize]
        [Authorize]
        public void Logout()
        {
            string authorizationHeader = Request.Headers["Authorization"];
            string token = authorizationHeader.Split("Bearer ")[1];
            _tokenService.Logout(token);
        }
    }
}
