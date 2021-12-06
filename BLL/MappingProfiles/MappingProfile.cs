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

            CreateMap<EnglishLevel, EnglishLevelDTO>();
            CreateMap<EnglishLevelDTO, EnglishLevel>();

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
            CreateMap<Specialization, SpecializationDTO>();
            CreateMap<SpecializationDTO, Specialization>();

            CreateMap<HRInterviewDTO, Interview>();

            CreateMap<InterviewMarksWithSkillIDDTO, SkillKnowledgeDTO>();
            CreateMap<HRInterviewDTO, SkillKnowledgeDTO>();



            //CreateMap<HRInterviewDTO, IEnumerable<SkillKnowledgeDTO>>()
            //    .ConvertUsing<HRInterviewDTOConverter>();


            CreateMap<HRInterviewDTO, InterviewMarksWithSkillIDDTO>();
            CreateMap<HRInterviewDTO, IEnumerable<SkillKnowledgeDTO>>()
                    .ConvertUsing(sourse => sourse.Marks.Select(p => new SkillKnowledgeDTO
                    {
                       // InterviewID = sourse.ID.Value,
                        Level = p.SkillLevel,
                        SkillID = p.SkillID
                    }));
        }

    }

    //public class SkillKnowledeWithMarksListDTOConverter : ITypeConverter<IEnumerable<HRInterviewDTO>, IEnumerable<SkillKnowledge>>
    //{
    //    public IEnumerable<SkillKnowledge> Convert(IEnumerable<HRInterviewDTO> source, IEnumerable<SkillKnowledge> destination, ResolutionContext context)
    //    {
    //        foreach (var item in source)
    //        {
    //            foreach (var item2 in context.Mapper.Map<IEnumerable<SkillKnowledge>>(item))
    //            {
    //                yield return item2;
    //            }
    //        }
    //    }
    //}

        //class HRInterviewDTOConverter : ITypeConverter<HRInterviewDTO, IEnumerable<SkillKnowledgeDTO>>
        //{
        //    public IEnumerable<SkillKnowledgeDTO> Convert(
        //            HRInterviewDTO source,
        //            IEnumerable<SkillKnowledgeDTO> destination,
        //            ResolutionContext context)
        //    {
        //        foreach (var dto in source.Marks.Select(e => context.Mapper.Map<SkillKnowledgeDTO>(e)))
        //        {
        //            context.Mapper.Map(source, dto);
        //            yield return dto;
        //        }
        //    }
        //}
}

