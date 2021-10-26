using System.Collections.Generic;
using DAL.Models;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using System.Linq;

namespace BLL.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _candidateRep;

        public CandidateService(IUnitOfWork candidateRep)
        {
            _candidateRep = candidateRep;
        }

        public void AddCandidate(CandidateForm formData)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CandidateForm, Candidate>()).CreateMapper();
            var mapper = new Mapper((IConfigurationProvider)config);
            var candidate = mapper.Map<Candidate>(formData);
            _candidateRep.Candidates.Save(candidate);
            _candidateRep.Save();
        }

        public void DeleteCandidate(int id)
        {
            var candidate = _candidateRep.Candidates.Get(id);
            _candidateRep.Candidates.Remove(candidate);
            _candidateRep.Save();
        }

        //Вернуть список данных из форм кандидатов
        public IEnumerable<CandidateForm> GetAllCandidateForms()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Candidate, CandidateForm>()).CreateMapper();
            return mapper.Map<IEnumerable<Candidate>, List<CandidateForm>>(_candidateRep.Candidates.GetAll());
        }

        public CandidateForm GetCandidateFormById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Candidate, CandidateForm>()).CreateMapper();
            return mapper.Map<Candidate, CandidateForm>(_candidateRep.Candidates.Get(id));
        }

    }
}
