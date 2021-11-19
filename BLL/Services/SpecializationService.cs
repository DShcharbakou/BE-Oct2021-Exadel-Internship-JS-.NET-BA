//using System.Collections.Generic;
//using DAL.Models;
//using DAL.Repositories;
//using BLL.Interfaces;
//using BLL.DTO;
//using AutoMapper;
//using System.Linq;

//namespace BLL.Services
//{
//    public class SpecializationService : ISpecializationService
//    {
//        private readonly IUnitOfWork _db;
//        private readonly IMapper _mapper;
//        public SpecializationService(IUnitOfWork db, IMapper mapper)
//        {
//            _db = db;
//            _mapper = mapper;
//        }

//        public void GetCandidate(string name)
//        {
//            var specialization = _db.Specializations.
//        }

//        //public void AddCandidate(CandidateDTO formData)
//        //{
//        //    var candidate = _mapper.Map<Candidate>(formData);
//        //    _db.Candidates.Save(candidate);
//        //    _db.Save();
//        //}

//        //public void DeleteCandidate(int id)
//        //{
//        //    var candidate = _db.Candidates.Get(id);
//        //    _db.Candidates.Remove(candidate);
//        //    _db.Save();
//        //}

//        ////Вернуть список данных из форм кандидатов
//        //public IEnumerable<CandidateDTO> GetAllCandidates()
//        //{
//        //    return _mapper.Map<IEnumerable<Candidate>, List<CandidateDTO>>(_db.Candidates.GetAll());
//        //}

//        //public CandidateDTO GetCandidateById(int id)
//        //{
//        //    return _mapper.Map<Candidate, CandidateDTO>(_db.Candidates.Get(id));
//        //}

//    }
//}
