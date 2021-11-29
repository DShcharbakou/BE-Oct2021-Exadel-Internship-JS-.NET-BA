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
        private readonly ICandidateService _candidateService;
        private readonly IEmployeeService _employeeService;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public BaseController(ICandidateService candidateService,
                                IEmployeeService employeeService,
                                IMapper mapper,
                                UserManager<User> userManager)
        {
            _candidateService = candidateService;
            _userManager = userManager;
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet("candidates")]
        [Authorize(Roles = "admin, mentor")]
        public async Task<IEnumerable<CandidateDTO>> GetCandidates()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var employee = _employeeService.GetEmployeeByEmail(user.Email);
            IEnumerable<CandidateDTO> candidates = _candidateService.GetCandidatesFromTeam(currentTeam.TeamNumber);
            return candidates.ToList();
        }
    }
}
