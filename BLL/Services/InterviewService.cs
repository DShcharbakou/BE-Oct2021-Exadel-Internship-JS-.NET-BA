using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Models;

namespace BLL.Services
{
    public class InterviewService : IInterviewService
    {
        private readonly IUnitOfWork _interviewRep;
        public InterviewService(IUnitOfWork interview)
        {
            _interviewRep = interview;
        }

        public void AddInterview(InterviewDTO interviewDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<InterviewDTO, Interview>()).CreateMapper();
            var mapper = new Mapper((IConfigurationProvider)config);
            var interview = mapper.Map<Interview>(interviewDto);
            _interviewRep.Interviews.Save(interview);
            _interviewRep.Save();
        }

        public void DeleteInterview(int id)
        {
            var interview = _interviewRep.Interviews.Get(id);
            _interviewRep.Interviews.Remove(interview);
            _interviewRep.Save();
        }

        public InterviewDTO GetInterviewById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Interview, InterviewDTO>()).CreateMapper();
            return mapper.Map<Interview, InterviewDTO>(_interviewRep.Interviews.Get(id));
        }

        public IEnumerable<InterviewDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Interview, InterviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Interview>, List<InterviewDTO>>(_interviewRep.Interviews.GetAll());
        }
    }
}
