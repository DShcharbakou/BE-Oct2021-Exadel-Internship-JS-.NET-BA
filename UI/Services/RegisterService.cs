//using DAL;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UI.Models;


//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
//using UI.Models;
//using DAL;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using System.IdentityModel.Tokens.Jwt;
//using System;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;
//using Microsoft.Extensions.Configuration;

//namespace BLL.Services
//{
//    class RegisterService
//    {
//        private readonly UserManager<User> _userManager;

//        public RegisterService(UserManager<User> userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<RegisterModelResult> RegisterEmployee([FromBody] RegisterModelRequest model)
//        {
//            RegisterModelResult ErrorList = new RegisterModelResult();
//            ErrorList.ErrorList = new Dictionary<int, string>();

//            User user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email, Password = model.Password, UserName = model.Email };
//            // добавляем пользователя
//            var result = await _userManager.CreateAsync(user, model.Password);
//            int i = 0;
//            if (!result.Succeeded)
//            {
//                foreach (var error in result.Errors)
//                {
//                    //ModelState.AddModelError(string.Empty, error.Description);
//                    ErrorList.ErrorList.Add(i, error.Description);
//                    i++;
//                }
//            }
//            ErrorList.ErrorList.Add(i, "All Is good");

//            return ErrorList;
//        }
//    }
//}
