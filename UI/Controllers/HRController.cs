﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Models;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : Controller
    {

        readonly ICandidateService candidateService;

        public HRController(IUnitOfWork db,IMapper mapper, ICandidateService candidate)
        {
            candidateService = candidate;
        }

        // GET: api/<HRController>
        [HttpGet] // maybe there is must be renamed
        public List<CandidateDTO> Get()
        {
            return candidateService.GetAllCandidates();
        }

        // GET api/<HRController>/5
        [HttpGet("Get")]
        public CandidateDTO Get(int id)
        {
            return candidateService.GetCandidateById(id);
        }

        /*

         // GET api/<HRController>/5
         [HttpGet("{SpecializationId}")]
         public string Get(int id)
         {

             return "value";
         }
        */

        /*  // GET api/<HRController>/HRInter
          [HttpGet("{IsInterwievedByHR}")] // тоже должен вернуть по идее список кандидатов
          public CandidateDTO Get(string getInterw)
          {
              return "value";
          }


          // GET api/<HRController>/TechInter
          [HttpGet("{IsInterwievedByTech}")] //тоже должен вернуть по идее список кандидатов
          public string Get(bool answer)
          {
              return "value";
          }

          // GET api/<HRController>/decline
          [HttpGet("{Status}")] //тоже должен вернуть по идее список кандидатов
          public string Get(string status)
          {
              return "value";
          }
        */

        // POST api/<HRController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HRController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HRController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
