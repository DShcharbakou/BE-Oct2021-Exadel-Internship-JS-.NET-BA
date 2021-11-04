using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UI.Models;
using DAL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private ITokenService _tokenService;
 

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<RegisterModelResult> Register([FromBody] RegisterModelRequest model)
        {
            RegisterModelResult ErrorList = new RegisterModelResult();
            ErrorList.ErrorList = new Dictionary<int, string>();

            if (ModelState.IsValid) 
            {  
                User user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password, UserName = model.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                if (await _roleManager.RoleExistsAsync(model.Role))
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                }

                int i = 0;
                if (!result.Succeeded) 
                {
                    foreach (var error in result.Errors) 
                    {
                        //ModelState.AddModelError(string.Empty, error.Description);
                        ErrorList.ErrorList.Add(i, error.Description);
                        i++;
                    }
                }
                ErrorList.ErrorList.Add(i, "All Is good");
            }

            return ErrorList;
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
