using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using DAL.Repositories;
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
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager, IUnitOfWork db, IMapper mapper)
        {
            _userManager = userManager;
            _db = db;
            _mapper = mapper;
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
            if (!_userManager.FindByEmailAsync(email).IsCompleted)
            {
                IdentityResult resultCreating = _userManager.CreateAsync(user, user.Password).Result;
                if (resultCreating.Succeeded)
                {
                    IdentityResult resultRoleCreating = _userManager.AddToRoleAsync(user, role).Result;
                }

                EmployeeDTO employee = new EmployeeDTO();
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.Email = user.Email;

                var employ = _mapper.Map<Employee>(employee);
                _db.Employees.Save(employ);
                _db.Save();
            }
        }

        public void DeleteUser(string email)
        {
            var user = _userManager.FindByNameAsync(email).Result;
            _userManager.DeleteAsync(user);
        }
    }
}