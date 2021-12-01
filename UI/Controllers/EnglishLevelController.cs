using AutoMapper;
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
    public class EnglishLevelController : ControllerBase
    {
        private readonly IEnglishLevelService _englishLevelService;

        public EnglishLevelController(IEnglishLevelService englishLevelService)
        {
            _englishLevelService = englishLevelService;
        }

        [HttpGet("get-all-english-levels")]
        public List<EnglishLevelDTO> GetAllEnglishLevels()
        {
            return _englishLevelService.GetAllLevels();
        }

        [HttpGet("{id}/get-english-level-by-id")]
        public string GetEnglishLevelById(int id)
        {
            return _englishLevelService.GetEnglishLevelById(id);
        }
    }
}
