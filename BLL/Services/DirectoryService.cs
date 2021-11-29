using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class DirectoryService : IDirectoryService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public DirectoryService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public SpecializationDTO GetSpecializationById(int specializationId)
        {
            return _mapper.Map<Specialization, SpecializationDTO>(_db.Specializations.Get(specializationId));
        }

        public List<SpecializationDTO> GetAllSpecializations()
        {
            return _mapper.Map<List<Specialization>, List<SpecializationDTO>>(_db.Specializations.GetAll().ToList());
        }

        public EnglishLevelDTO GetEnglishLevelById(int englishLevelById)
        {
            return _mapper.Map<EnglishLevel, EnglishLevelDTO>(_db.EnglishLevels.Get(englishLevelById));
        }

        public List<EnglishLevelDTO> GetAllEnglishLevels()
        {
            return _mapper.Map<List<EnglishLevel>, List<EnglishLevelDTO>>(_db.EnglishLevels.GetAll().ToList());
        }

        public SkillDirectoryDTO GetSkillById(int skillId)
        {
            return _mapper.Map<Skill, SkillDirectoryDTO>(_db.Skills.Get(skillId));
        }

        public List<SkillDirectoryDTO> GetAllSkills()
        {
            return _mapper.Map<List<Skill>, List<SkillDirectoryDTO>>(_db.Skills.GetAll().ToList());
        }

        public TopicDTO GetTopicById(int topicId)
        {
            return _mapper.Map<Topic, TopicDTO>(_db.Topics.Get(topicId));
        }

        public List<TopicDTO> GetAllTopics()
        {
            return _mapper.Map<List<Topic>, List<TopicDTO>>(_db.Topics.GetAll().ToList());
        }

        public CountryDTO GetCountryById(int countryId)
        {
            return _mapper.Map<Country, CountryDTO>(_db.Countries.Get(countryId));
        }

        public List<CountryDTO> GetAllCountries()
        {
            return _mapper.Map<List<Country>, List<CountryDTO>>(_db.Countries.GetAll().ToList());
        }

        public StateDTO GetStateById(int stateId)
        {
            return _mapper.Map<State, StateDTO>(_db.States.Get(stateId));
        }

        public List<StateDTO> GetAllStates()
        {
            return _mapper.Map<List<State>, List<StateDTO>>(_db.States.GetAll().ToList());
        }

        public CityDTO GetCityById(int cityId)
        {
            return _mapper.Map<City, CityDTO>(_db.Cities.Get(cityId));
        }

        public List<CityDTO> GetAllCities()
        {
            return _mapper.Map<List<City>, List<CityDTO>>(_db.Cities.GetAll().ToList());
        }

        //public StatusDTO GetStatusById(int statusId)
        //{
        //    return _mapper.Map<Status, StatusDTO>(_db.Statuses.Get(statusId));
        //}

        //public List<StatusDTO> GetAllStatuses()
        //{
        //    return _mapper.Map<List<Status>, List<StatusDTO>>(_db.Statuses.GetAll().ToList());
        //}
    }
}
