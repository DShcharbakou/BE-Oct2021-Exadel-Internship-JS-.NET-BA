using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IDirectoryService
    {
        SpecializationDTO GetSpecializationById(int specializationId);
        List<SpecializationDTO> GetAllSpecializations();
        EnglishLevelDTO GetEnglishLevelById(int englishLevelById);
        List<EnglishLevelDTO> GetAllEnglishLevels();
        SkillDirectoryDTO GetSkillById(int skillId);
        List<SkillDirectoryDTO> GetAllSkills();
        TopicDTO GetTopicById(int topicId);
        List<TopicDTO> GetAllTopics();
        CountryDTO GetCountryById(int countryId);
        List<CountryDTO> GetAllCountries();
        StateDTO GetStateById(int stateId);
        List<StateDTO> GetAllStates();
        CityDTO GetCityById(int cityId);
        List<CityDTO> GetAllCities();
        //StatusDTO GetStatusById(int statusId);
        //List<StatusDTO> GetAllStatuses();
    }
}
