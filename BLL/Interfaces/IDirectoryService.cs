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
        void SaveSpecialization(List<SpecializationDTO> specializationsDto);
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
        string GetLocationById(int cityId);
        List<CityDTO> GetAllCities();
        List<CityDTO> GetAllCitiesByCountryId(int countryId);
        StatusDTO GetStatusById(int statusId);
        List<StatusDTO> GetAllStatuses();
    }
}
