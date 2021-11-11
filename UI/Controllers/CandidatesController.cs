using BLL.DTO;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Routing.Matching;
using BLL.Interfaces;
using BLL.Services;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private ICandidateService candidateService;
        // GET: api/Candidate/5
        [HttpGet]
        public List<CandidateDTO> GetAll()
        {
            return (List<CandidateDTO>)candidateService.GetAllCandidates();
        }
        [HttpGet]
        public CandidateDTO GetById(int id,[FromBody] CandidateDTO candidate)
        {
            return candidateService.GetCandidateById(id);
        }
        [HttpPost("{id}")]
        public void Save(int id, [FromBody] CandidateDTO candidate)
        {
            candidateService.AddCandidate(candidate);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] CandidateDTO candidate)
        {
            candidateService.DeleteCandidate(id);
        }

    }
   
}

