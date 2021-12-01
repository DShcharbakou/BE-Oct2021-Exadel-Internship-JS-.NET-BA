using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Models;

namespace BLL.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Candidate, CandidateDTO>();
              /*  .ForMember(cd => cd.ID,
                 cd => cd.MapFrom(cd => cd.Id);*/
            CreateMap<CandidateDTO, Candidate>();


            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<InternshipTeamDTO, InternshipTeam>();
            CreateMap<InternshipTeam, InternshipTeamDTO>();

            CreateMap<InterviewDTO, Interview>();
            CreateMap<Interview, InterviewDTO>();

            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>();

            CreateMap<TopicDTO, Topic>();
            CreateMap<Topic, TopicDTO>();

            CreateMap<Sandbox, SandboxDTO>();
            CreateMap<SandboxDTO, Sandbox>();

            CreateMap<CandidateDTO, CandidateForMentorDTO>();

            CreateMap<EnglishLevel, EnglishLevelDirectoryDTO>();
            CreateMap<EnglishLevelDirectoryDTO, EnglishLevel>();

            CreateMap<Skill, SkillDirectoryDTO>();
            CreateMap<SkillDirectoryDTO, Skill>();

            CreateMap<Specialization, SpecializationDTO>();
            CreateMap<SpecializationDTO, Specialization>();

            CreateMap<Country, CountryDTO>();
            CreateMap<CountryDTO, Country>();

            CreateMap<State, StateDTO>();
            CreateMap<StateDTO, State>();

            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<CandidateSandboxDTO, CandidateSandbox>();
            CreateMap<CandidateSandbox, CandidateSandboxDTO>();

            CreateMap<EnglishLevel, EnglishLevelDTO>()
                .ForMember(cd => cd.Id,
                           cd => cd.MapFrom(cd => cd.Id));
            CreateMap<EnglishLevelDTO, EnglishLevel>();
        }
    }
}
