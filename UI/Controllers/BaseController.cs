using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public BaseController(  IEmployeeService employeeService,
                                IMapper mapper,
                                UserManager<User> userManager)
        {
            _userManager = userManager;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        
        protected async Task<EmployeeDTO> GetEmployee()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var employee = _employeeService.GetEmployeeByEmail(user.Email);
            return _employeeService.GetEmployeeByEmail(employee.Email);
           
        }
    }
}
