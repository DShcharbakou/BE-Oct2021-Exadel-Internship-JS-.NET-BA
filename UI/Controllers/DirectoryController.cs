using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectoryController : Controller
    {
        private readonly IDirectoryService _directoryService;
        public DirectoryController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet("GetSpecializationById")]
        public SpecializationDTO GetSpecializationById(int specializationId)
        {
            return _directoryService.GetSpecializationById(specializationId);
        }

        [HttpGet("GetAllSpecializations")]
        public List<SpecializationDTO> GetAllSpecializations()
        {
            return _directoryService.GetAllSpecializations();
        }

        [HttpGet("GetEnglishLevelById")]
        public EnglishLevelDTO GetEnglishLevelById(int englishLevelId)
        {
            return _directoryService.GetEnglishLevelById(englishLevelId);
        }

        [HttpGet("GetAllEnglishLevels")]
        public List<EnglishLevelDTO> GetAllEnglishLevels()
        {
            return _directoryService.GetAllEnglishLevels();
        }

        [HttpGet("GetCityById")]
        public CityDTO GetCityById(int cityId)
        {
            return _directoryService.GetCityById(cityId);
        }

        [HttpGet("GetAllCities")]
        public List<CityDTO> GetAllCities()
        {
            return _directoryService.GetAllCities();
        }

        [HttpGet("GetCountryById")]
        public CountryDTO GetCountryById(int countryId)
        {
            return _directoryService.GetCountryById(countryId);
        }

        [HttpGet("GetAllCountries")]
        public List<CountryDTO> GetAllCountries()
        {
            return _directoryService.GetAllCountries();
        }

        [HttpGet("GetSkillById")]
        public SkillDirectoryDTO GetSkillById(int skillId)
        {
            return _directoryService.GetSkillById(skillId);
        }

        [HttpGet("GetAllSkills")]
        public List<SkillDirectoryDTO> GetAllSkills()
        {
            return _directoryService.GetAllSkills();
        }

        [HttpGet("GetTopicById")]
        public TopicDTO GetTopicById(int topicId)
        {
            return _directoryService.GetTopicById(topicId);
        }

        [HttpGet("GetAllTopics")]
        public List<TopicDTO> GetAllTopics()
        {
            return _directoryService.GetAllTopics();
        }

        [HttpGet("GetStateById")]
        public StateDTO GetStateById(int stateId)
        {
            return _directoryService.GetStateById(stateId);
        }

        [HttpGet("GetAllStates")]
        public List<StateDTO> GetAllStates()
        {
            return _directoryService.GetAllStates();
        }

        //[HttpGet("GetStatusById/{id}")]
        //public StatusDTO GetStatusById(int statusId)
        //{
        //    return _directoryService.GetStatusById(statusId);
        //}

        //[HttpGet("GetAllStatuses")]
        //public List<StatusDTO> GetAllStatuses()
        //{
        //    return _directoryService.GetAllStatuses();
        //}
    }
}
