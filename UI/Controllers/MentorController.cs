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
        private readonly IInternshipTeamService _internshipTeamService;
        private readonly ISpecializationService _specializationService;
        private readonly IEnglishLevelService _englishLevelService;
        private readonly ICityService _cityService;
        private readonly UserManager<User> _userManager;

        public MentorController(ICandidateService candidateService,
                                ISpecializationService specializationService,
                                IInternshipTeamService internshipTeamService,
                                IEmployeeService employeeService,
                                IEnglishLevelService englishLevelService,
                                ICityService cityService,
                                UserManager<User> userManager)
        {
            _candidateService = candidateService;
            _userManager = userManager;
            _employeeService = employeeService;
            _internshipTeamService = internshipTeamService;
            _specializationService = specializationService;
            _englishLevelService = englishLevelService;
            _cityService = cityService;
        }

        // GET: api/<MentorController>
        [HttpGet]
        //[Route("api/mentor/candidates")]
        [Authorize(Roles = "admin, mentor")]
        public async Task<List<CandidateDTO>> GetCandidates()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var employee = _employeeService.GetEmployeeByEmail(user.Email);
            var currentTeam = _internshipTeamService.GetInternshipTeamByEmployeeId(employee.Id);
            var candidates = _candidateService.GetCandidatesFromTeam(currentTeam.TeamNumber);
            return candidates.ToList();
        }

        // GET api/<MentorController>/5

        [HttpGet("{id}")]
        //[Route("api/mentor/{id}")]
        public CandidateForMentorDTO GetFormData(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            CandidateForMentorDTO formData = new();
            formData.FirstName = candidate.FirstName;
            formData.LastName = candidate.LastName;
            formData.Email = candidate.Email;
            formData.Phone = candidate.Phone;
            formData.Skype = candidate.Skype;
            formData.Specialization = _specializationService.GetSpecializationById(candidate.ID);
            formData.Location = _cityService.GetCityById(candidate.ID);
            formData.EnglishLevel = _englishLevelService.GetEnglishLevelById(candidate.ID);
            return formData;
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
