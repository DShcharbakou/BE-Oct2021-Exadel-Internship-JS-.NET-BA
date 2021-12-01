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
        private readonly ISkillService _skillService;
        private readonly ICandidateSandboxService _candidateSandboxService;
        private readonly IMapper _mapper;
        public MentorController(ICandidateSandboxService candidateSandboxService, ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _candidateSandboxService = candidateSandboxService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "admin, mentor")]
        [HttpGet("{id}/get-skills-for-mentors-candidate")]
        public List<SkillDTO> GetSkillsForMentorsCandidate(int id)
        {
            var skills = _skillService.GetListWithSpec(id);
            return skills;
        }

        [HttpGet("{id}/get-comments-for-candidate")]
        public List<CommentsDTO> GetComments(int id)
        {
            var comments = _skillService.GetAllComments(id);
            return comments;
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
