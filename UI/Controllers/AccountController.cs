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

namespace UI.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

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
        public async Task<RegisterModelResult> Login([FromBody] LoginModelRequest model)
        {
            int i = 0;
            RegisterModelResult ErrorList = new RegisterModelResult();
            ErrorList.ErrorList = new Dictionary<int, string>();

            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                ErrorList.ErrorList.Add(i, "email or password is null");
                i++;
            }

            var user = await _userManager.FindByEmailAsync(model.Email.Normalize());
            if (user == null)
            {
                ErrorList.ErrorList.Add(i, "Invalid Login and/or password");
                i++;
            }



            if (!user.EmailConfirmed)
            {
                ErrorList.ErrorList.Add(i, "Email not confirmed, please check your email for confirmation link");
                i++;
            }

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
            {
                ErrorList.ErrorList.Add(i, "Invalid Login and/or password");
                i++;
            }
            else
            {
                await Authenticate(model.Email);
                ErrorList.ErrorList.Add(i, "All is qood");
                i++;
            }


            return ErrorList;
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost("Logout")]
        public async void Logout()
        {

            await _signInManager.SignOutAsync();
        }
    }
}
