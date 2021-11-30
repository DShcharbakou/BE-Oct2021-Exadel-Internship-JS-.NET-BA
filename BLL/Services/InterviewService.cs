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
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public InterviewService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void AddInterview(InterviewDTO interviewDto)
        {
            var interview = _mapper.Map<Interview>(interviewDto);
            _db.Interviews.Save(interview);
            _db.Save();
        }

        public void DeleteInterview(int id)
        {
            var interview = _db.Interviews.Get(id);
            _db.Interviews.Remove(interview);
            _db.Save();
        }

        public InterviewDTO GetInterviewById(int id)
        {
            return _mapper.Map<Interview, InterviewDTO>(_db.Interviews.Get(id));
        }

        public IEnumerable<InterviewDTO> GetList()
        {
            return _mapper.Map<IEnumerable<Interview>, List<InterviewDTO>>(_db.Interviews.GetAll());
        }

        public void AddHRInterview(HRInterviewDTO hrInterviewDTO) //it doesn't work correctly, need to change
        {
            var interview = _mapper.Map<Interview>(hrInterviewDTO);
            _db.Interviews.Save(interview);
            _db.Save();
        }
    }
}
