using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.MappingProfiles;
using BLL.Services;
using DAL;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : BaseController
    {

        readonly ICandidateService candidateService;
        readonly IInterviewService _interviewService;
        readonly ISkillKnowledgeService _skillKnowledgeService;
        readonly ICandidateSandboxService _candidateSandboxService;
        

        public HRController(IUnitOfWork db,IMapper mapper, ICandidateService candidate,
               UserManager<User> userManager, IEmployeeService employeeService,IInterviewService interviewService,
               ISkillKnowledgeService skillKnowledgeService, ICandidateSandboxService candidateSandboxService) : base(employeeService, mapper, userManager)
        {
            candidateService = candidate;
            _interviewService = interviewService;
            _skillKnowledgeService = skillKnowledgeService;
            _candidateSandboxService = candidateSandboxService;
        }

        // GET: api/<HRController>
        [HttpGet("GetAllCandidates")]
        public List<CandidateDTOForGetAll> Get()
        {
            return candidateService.GetAllCandidatesWithStatuses();
        }

        // GET api/<HRController>/5
        [HttpGet("ID")]
        public CandidateDTO Get(int id)
        {
            return candidateService.GetCandidateByIdWithStatuses(id);
        }

        [Authorize]
        // POST api/<HRController>
        [HttpPost("InterviewResults")]
        public async Task Post([FromBody] HRInterviewResults hrInterviewResultsUI)
        {
            await SetInterviewAndSkillKnowledges(hrInterviewResultsUI);
        }

        [Authorize]
        [HttpPost("InterviewResultsWithDeclineStatus")]
        public async Task Post([FromBody] HRInterviewResultsWithStatus hrInterviewDTODecline)
        {
            await SetInterviewAndSkillKnowledges(hrInterviewDTODecline);
            var hRInterviewWithStatus = _mapper.Map<HRInterviewDTOWithStatus>(hrInterviewDTODecline);
            _candidateSandboxService.SetStatusAfterHrInterview(hRInterviewWithStatus);
        }

        private async Task SetInterviewAndSkillKnowledges(HRInterviewResults hrInterviewResultsUI)
        {
            HRInterviewDTO hRInterview = _mapper.Map<HRInterviewDTO>(hrInterviewResultsUI);
            var employee = await GetEmployee();
            hRInterview.EmployeeID = employee.Id;
            hRInterview.ID = _interviewService.AddHRInterview(hRInterview);

            var skillKnowledgeDTOList = _mapper.Map<IEnumerable<SkillKnowledgeDTO>>(hRInterview);
            _skillKnowledgeService.AddSkillKnowledge(skillKnowledgeDTOList);
        }
    }
}