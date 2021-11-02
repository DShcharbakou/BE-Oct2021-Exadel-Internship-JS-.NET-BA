using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Models;

namespace UI.Controllers
{
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interviewService;

        public InterviewController(IInterviewService interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpGet]
        public IEnumerable<InterviewDTO> GetInterviewList()
        {
            return _interviewService.GetList();
        }

        [HttpGet]
        public InterviewDTO GetInterview(int id)//InterviewModel?
        {
            return _interviewService.GetInterviewById(id);
        }

        [HttpPost]
        //[Produces("application/json")]
        public void CreateNewInterview([FromBody] InterviewDTO viewModel)
        {
            _interviewService.AddInterview(viewModel);
        }

        [HttpDelete]
        public void DeleteInterview(int id)//InterviewModel?
        {
            _interviewService.DeleteInterview(id);
        }
    }
}
