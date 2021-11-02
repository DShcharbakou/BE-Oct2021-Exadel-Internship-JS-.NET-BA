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

namespace UI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private TockenControl tockenControl;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            tockenControl = new TockenControl();
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
            var user = await _userManager.FindByNameAsync(model.Email.Normalize());
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
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

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost("Logout")]
        public void Logout([FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                tockenControl.Update();
                var scheme = headerValue.Scheme;
                var parameter = headerValue.Parameter;

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(parameter);
                tockenControl.Logout(parameter, jsonToken.ValidTo);
                tockenControl.Update();
                tockenControl.Save();
            }
        }
    }
}
