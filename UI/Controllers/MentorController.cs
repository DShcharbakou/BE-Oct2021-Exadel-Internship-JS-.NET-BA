﻿using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ISkillService _skillService;
        private readonly ICandidateSandboxService _candidateSandboxService;
        private readonly IMapper _mapper;
        public MentorController(ICandidateService candidateService, ICandidateSandboxService candidateSandboxService, ISkillService skillService, IMapper mapper)
        {
            _candidateService = candidateService;
            _skillService = skillService;
            _candidateSandboxService = candidateSandboxService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "admin, mentor")]
        [HttpGet("{id}/get-skills-for-mentors-team")]
        public List<SkillDTO> GetSkillsForMentorsTeam(int id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            var skills = _skillService.GetListWithSpec(candidate.ID);
            return skills;
        }

        [HttpPost("{model}/add-assessment")]
        public ActionResult AddAssessment(AssessmentModel model)
        {
            var candidateSandboxDTO = _mapper.Map<CandidateSandboxDTO>(model);
            _candidateSandboxService.AddGradeAndComment(candidateSandboxDTO);
            return Ok();
        }

    }
}
