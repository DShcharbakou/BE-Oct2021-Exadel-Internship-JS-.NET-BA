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
            CreateMap<CandidateDTO, Candidate>();
            CreateMap<Candidate, CandidateDTO>();

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();

            CreateMap<InternshipTeamDTO, InternshipTeam>();
            CreateMap<InternshipTeam, InternshipTeamDTO>();

            CreateMap<InterviewDTO, Interview>();
            CreateMap<Interview, InterviewDTO>();

            CreateMap<StackDTO, Skill>();
            CreateMap<Skill, StackDTO>();

            CreateMap<TopicDTO, Topic>();
            CreateMap<Topic, TopicDTO>();
        }
    }
}
