using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Models;
using System.Linq;

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

        public int AddHRInterview(HRInterviewDTO hrInterviewDTO)
        {
            var interview = _mapper.Map<Interview>(hrInterviewDTO);
            var intID = _db.Interviews.SaveWithReturningID(interview);
            _db.Save();
            return intID;
        }

        public void SaveCommentForTech(TechSkillsDTO model)
        {
            var secondInterview = _mapper.Map<InterviewDTO>(_db.Interviews.GetAll().Where(x => x.CandidateID == model.CandidateId).LastOrDefault());
            secondInterview.Comment = model.TechComment;
            var mapped = _mapper.Map<Interview>(secondInterview);
            _db.Interviews.Save(mapped);
            _db.Save();
        }

    }
}
