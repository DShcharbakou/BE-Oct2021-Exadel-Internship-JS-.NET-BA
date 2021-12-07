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
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IDirectoryService _directoryService;

        public CandidateController(ICandidateService candidateService,
                                IInternshipTeamService internshipTeamService,
                                IEmployeeService employeeService,
                                IMapper mapper,
                                UserManager<User> userManager,
                                IDirectoryService directoryService)
        {
            _candidateService = candidateService;
            _userManager = userManager;
            _employeeService = employeeService;
            _internshipTeamService = internshipTeamService;
            _mapper = mapper;
            _directoryService = directoryService;
        }

        [HttpGet("get-candidates-for-mentor")]
        [Authorize(Roles = "admin, mentor")]
        public async Task<IEnumerable<CandidateDTO>> GetCandidatesForMentor()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var employee = _employeeService.GetEmployeeByEmail(user.Email);
            var currentTeam = _internshipTeamService.GetInternshipTeamByEmployeeId(employee.Id);
            IEnumerable<CandidateDTO> candidates = _candidateService.GetCandidatesFromTeam(currentTeam.TeamNumber);
            return candidates.ToList();
        }

        [HttpGet("{id}/get-form")]
        public CandidateForMentorDTO GetForm(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            var formData = _mapper.Map<CandidateForMentorDTO>(candidate);
            formData.Specialization = _directoryService.GetSpecializationById(candidate.SpecializationID).Name;
            formData.Location = _directoryService.GetLocationById(candidate.CityID);
            formData.EnglishLevel = _directoryService.GetEnglishLevelById(candidate.EnglishLevelID).LevelName;
            return formData;
        }

        
        [HttpPost("RegisterCandidate")]
        public IActionResult RegisterCandidate(CandidateDTO model)
        {
            if (_candidateService.FindCandidates(model.Email).Count() < 1)
            {
                _candidateService.AddCandidate(model);
                return Ok();
            }
            else
            {
                return BadRequest("Requested candidate is exist in database");
            }

        }

        [HttpGet("get-candidates-for-tech")]
        public List<CandidateForTechDTO> GetCandidatesForTech()
        {
            return _candidateService.GetAllCandidatesWithHrInterview().ToList();
        }

        [HttpPost("SaveCV")]
        public IActionResult SaveCV(AddFileDTO model)
        {
            _candidateService.SaveCV(model);
            return Ok();
        }
    }
}