using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IEmployeeService _employeeService;
        private readonly IInternshipTeamService _internshipTeamService;
        private readonly ISpecializationService _specializationService;
        private readonly IEnglishLevelService _englishLevelService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CandidateController(ICandidateService candidateService,
                                ISpecializationService specializationService,
                                IInternshipTeamService internshipTeamService,
                                IEmployeeService employeeService,
                                IEnglishLevelService englishLevelService,
                                ICityService cityService,
                                IMapper mapper,
                                UserManager<User> userManager)
        {
            _candidateService = candidateService;
            _userManager = userManager;
            _employeeService = employeeService;
            _internshipTeamService = internshipTeamService;
            _specializationService = specializationService;
            _englishLevelService = englishLevelService;
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("candidates")]
        [Authorize(Roles = "admin, mentor")]
        public async Task<List<CandidateDTO>> GetCandidates()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var employee = _employeeService.GetEmployeeByEmail(user.Email);
            var currentTeam = _internshipTeamService.GetInternshipTeamByEmployeeId(employee.Id);
            var candidates = _candidateService.GetCandidatesFromTeam(currentTeam.TeamNumber);
            return candidates.ToList();
        }

        [HttpGet("{id}/form")]
        //[Authorize(Roles = "admin, mentor")]
        public CandidateForMentorDTO GetForm(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            var formData = _mapper.Map<CandidateForMentorDTO>(candidate);
            formData.Specialization = _specializationService.GetSpecializationById(candidate.ID);
            formData.Location = _cityService.GetLocationById(candidate.ID);
            formData.EnglishLevel = _englishLevelService.GetEnglishLevelById(candidate.ID);
            return formData;
        }
    }
}
