using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UI.Models;
using DAL;
using System.Collections.Generic;
using UI.Attributes;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BLL.DTO;

namespace UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICandidateService _candidateService;
        private readonly IDirectoryService _directoryService;
        private readonly ICandidateSandboxService _candidateSandboxService;

        public AdminController(
            IUserService userService, 
            ICandidateService candidateService,
            IDirectoryService directoryService,
            ICandidateSandboxService candidateSandboxService)
        {
            _userService = userService;
            _candidateService = candidateService;
            _directoryService = directoryService;
            _candidateSandboxService = candidateSandboxService;
        }

        [HttpPost("searchCandidates")]
        public IEnumerable<CandidateDTO> SerchCandidate([FromBody] string searchText)
        {
            return _candidateService.FindCandidates(searchText);
        }

        [HttpPost("addingUser")]
        public void UserAdd([FromBody] AddingUser user)
        {
            _userService.AddingUser(user.email, user.password, user.firstName, user.lastName, user.role);
        }

        [HttpPost("deleteUser")]
        public void UserDelete([FromBody] string email)
        {
            _userService.DeleteUser(email);
        }

        [HttpGet("getAllSpecializations")]
        public IEnumerable<SpecializationDTO> GetAllSpecialization()
        {
            return _directoryService.GetAllSpecializations();
        }

        [HttpPost("SaveSpecializations")]
        public void SaveAllSpecialization([FromBody] List<SpecializationDTO> specializations)
        {
            _directoryService.SaveSpecialization(specializations);
        }
        [HttpPost("SetCandidateStatus")]
        public void SetCandidateStatus([FromBody] CandidateDTO candidateDTO, int statusID)
        {
            _candidateSandboxService.SetStatus(candidateDTO, statusID);
        }
    }
}
