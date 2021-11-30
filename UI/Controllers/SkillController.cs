using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        //[Authorize]
        [HttpGet("get-all-skills")]
        public List<Skill2DTO> GetAllSkills()
        {
            return _skillService.GetListSkill2DTO().ToList();
        }

        [HttpGet("{id}/get-skill-by-id")]
        public Skill2DTO GetSkillById(int id)
        {
            return _skillService.GetSkillById(id);
        }
    }
}
