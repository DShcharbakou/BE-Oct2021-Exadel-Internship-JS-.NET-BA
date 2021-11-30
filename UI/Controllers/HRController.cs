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
       

        public HRController(IUnitOfWork db,IMapper mapper, ICandidateService candidate,
               UserManager<User> userManager, IEmployeeService employeeService, IInterviewService interviewService) : base(employeeService, mapper, userManager)
        {
            candidateService = candidate;
            _interviewService = interviewService;
        }

        // GET: api/<HRController>
        [HttpGet("GetAllCandidates")]
        public List<CandidateDTOForGetAll> Get()
        {
            //var employee = GetEmployee();
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
        public async Task Post([FromBody] HRInterviewResults hrInterviewresult) //it doesn't work correctly, need to change
        {
            HRInterviewDTO hRInterview = _mapper.Map<HRInterviewDTO>(hrInterviewresult);
            var employee = await GetEmployee();
            hRInterview.EmployeeID = employee.Id;
            _interviewService.AddHRInterview(hRInterview);
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