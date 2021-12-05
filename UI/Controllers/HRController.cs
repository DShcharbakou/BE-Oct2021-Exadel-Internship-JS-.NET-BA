using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Models;
using DAL.Repositories;
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



        public HRController(IUnitOfWork db,IMapper mapper, ICandidateService candidate,
               UserManager<User> userManager, IEmployeeService employeeService,IInterviewService interviewService,
               ISkillKnowledgeService skillKnowledgeService) : base(employeeService, mapper, userManager)
        {
            candidateService = candidate;
            _interviewService = interviewService;
            _skillKnowledgeService = skillKnowledgeService;
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
        
        // POST api/<HRController>
        [HttpPost("InterviewResults")]
        public async Task Post([FromBody] HRInterviewResults hrInterviewResultsUI) //it doesn't work correctly, need to change
        {
            HRInterviewDTO hRInterview = _mapper.Map<HRInterviewDTO>(hrInterviewResultsUI);
            var employee = await GetEmployee();
            hRInterview.EmployeeID = employee.Id;
            _interviewService.AddHRInterview(hRInterview);

            var tempSkillKnowledge = new List<SkillKnowledgeWithMarksListDTO>();

            foreach (var tempMarksList in hRInterview.Marks)
            {
                var mapResult = _mapper.Map<SkillKnowledgeWithMarksListDTO>(hRInterview);
                _mapper.Map(tempMarksList, mapResult);

                tempSkillKnowledge.Add(mapResult);
            }

            var marks = new List<InterviewMarksWithSkillIDDTO>();
            foreach (var tempMark in tempSkillKnowledge)
            {
                var mappingResult = _mapper.Map<InterviewMarksWithSkillIDDTO>(tempSkillKnowledge);
                _mapper.Map(tempMark, mappingResult);

                marks.Add(mappingResult);
            }
            var skillKnowledge = _mapper.Map<SkillKnowledgeDTO>(tempSkillKnowledge);
            foreach (var intervMarks in marks)
            { 

            }

            skillKnowledge.SkillID = marks.SkillID;
            skillKnowledge.Level = marks.SkillLevel;


            //var tempSkillKnowledge = _mapper.Map<SkillKnowledgeWithMarksListDTO>(hRInterview);//получаю объект с листом оценок и скиллов
            //var marks = _mapper.Map<InterviewMarksWithSkillIDDTO>(tempSkillKnowledge.MarksList);//перекидываю лист с оценками и скиллами в новые??? листы. но у меня будет таким образом только один лист заполняться, а не создаваться новые и соответственно заполняться
            //add new map in map profile for mapping from list to objects
            //var skillKnowledge = _mapper.Map<SkillKnowledgeDTO>(tempSkillKnowledge);
            //skillKnowledge.SkillID = marks.SkillID;
            //skillKnowledge.Level = marks.SkillLevel;

            //_skillKnowledgeService.AddSkillKnowledge(skillKnowledge);
        }

        [HttpPost("InterviewResultsWithDeclineStatus")]
        public void Post([FromBody] HRInterviewDTOWithDecline hrInterviewDTODecline)
        { }

        // PUT api/<HRController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        { }
    }
}