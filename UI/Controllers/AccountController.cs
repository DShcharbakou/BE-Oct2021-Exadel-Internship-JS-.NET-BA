﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

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
        public async Task<IActionResult> Register(/*RegisterModel model*/)
        {
            /* if (ModelState.IsValid)
             {
                 User user = new User { Email = model.Email, UserName = model.Email, Year = model.Year };
                 // добавляем пользователя
                 var result = await _userManager.CreateAsync(user, model.Password);
                 if (result.Succeeded)
                 {
                     // установка куки
                     await _signInManager.SignInAsync(user, false);
                     return RedirectToAction("Index", "Home");
                 }
                 else
                 {
                     foreach (var error in result.Errors)
                     {
                         ModelState.AddModelError(string.Empty, error.Description);
                     }
                 }
             }
            */
             return Json("Dest");
        }
    }
}
