using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IEmployeeService _employeeService;
        private readonly IInternshipTeamService _internshipTeam;
        private readonly UserManager<User> _userManager;

        public MentorController(ICandidateService candidateService, IInternshipTeamService internshipTeam, IEmployeeService employeeService, UserManager<User> userManager)
        {
            _candidateService = candidateService;
            _userManager = userManager;
            _employeeService = employeeService;
            _internshipTeam = internshipTeam;
        }

        // GET: api/<MentorController>
        [HttpGet]
        [Authorize(Roles = "admin, mentor")]
        public async Task<List<CandidateDTO>> GetCandidates()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var employee = _employeeService.GetEmployeeByEmail(user.Email);
            var currentTeam = _internshipTeam.GetInternshipTeamByEmployeeId(employee.Id);
            var result = _candidateService.GetCandidatesFromTeam(currentTeam.TeamNumber);
            return result.ToList();
        }

        // GET api/<MentorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MentorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MentorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MentorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
