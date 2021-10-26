using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<RegisterModelResult> Register([FromBody] RegisterModelRequest model)
        {
            RegisterModelResult ErrorList = new RegisterModelResult();
            if (ModelState.IsValid) 
            {  
                User user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password, UserName = model.Username };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                ErrorList.ErrorList = new Dictionary<int, string>();
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
        public async Task<RegisterModelResult> Login(LoginModelRequest model)
        {
            int i = 0;
            RegisterModelResult ErrorList = new RegisterModelResult();

            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                ErrorList.ErrorList.Add(i, "email or password is null");
                i++;
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
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
                ErrorList.ErrorList.Add(i, "All is qood");
                i++;
            }

            return ErrorList;
        }

        [HttpPost("Logout")]
        public async void Logout()
        {
            RegisterModelResult ErrorList = new RegisterModelResult();
            await _signInManager.SignOutAsync();
        }
    }
}
