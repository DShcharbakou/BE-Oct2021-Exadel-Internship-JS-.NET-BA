using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class UserService : IUserService
    {
        private UserManager<User> _userManager;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public void AddingUser(string email, string password, string firstName, string lastName, string role)
        {
            User user = new User
            {
                UserName = email,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };
            IdentityResult resultCreating = _userManager.CreateAsync(user, user.Password).Result;
            if (resultCreating.Succeeded) 
            {

                IdentityResult resultRoleCreating = _userManager.AddToRoleAsync(user, role).Result;

            }


        }

        public void DeleteUser(string email)
        {

            var user = _userManager.FindByNameAsync(email).Result;
            _userManager.DeleteAsync(user);
        }
    }
}
