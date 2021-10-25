using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<RegisterModelResult> Register(RegisterModelRequest model)
        {
            RegisterModelResult ErrorList = new RegisterModelResult();
            if (ModelState.IsValid) 
            {  
                User user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password, };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded) 
                {
                    foreach (var error in result.Errors) 
                    {
                        //ModelState.AddModelError(string.Empty, error.Description);
                        ErrorList.ErrorList.Add(string.Empty, error.Description);
                    }
                }
                ErrorList.ErrorList.Add(string.Empty, "All Is good");
            }

            return ErrorList;
        }

        [HttpPost]
        public async Task<RegisterModelResult> Login(LoginModelRequest model)
        {
            RegisterModelResult ErrorList = new RegisterModelResult();

            if (string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Password))
            {
                ErrorList.ErrorList.Add(string.Empty, "email or password is null");
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ErrorList.ErrorList.Add(string.Empty, "Invalid Login and/or password");
            }

            if (!user.EmailConfirmed)
            {
                ErrorList.ErrorList.Add(string.Empty, "Email not confirmed, please check your email for confirmation link");
            }

            var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!passwordSignInResult.Succeeded)
            {
                ErrorList.ErrorList.Add(string.Empty, "Invalid Login and/or password");
            } 
            else
            {
                ErrorList.ErrorList.Add(string.Empty, "All is qood");
            }

            return ErrorList;
        }

        [HttpPost]
        public async void Logout()
        {
            RegisterModelResult ErrorList = new RegisterModelResult();
            await _signInManager.SignOutAsync();
        }
    }
}
