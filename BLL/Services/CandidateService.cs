using System.Collections.Generic;
using BLL.Interfaces;
using BLL.DTO;
using DAL.Repositories;

namespace BLL.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _candidateRep;

        public CandidateService(IUnitOfWork candidateRep)
        {
            _candidateRep = candidateRep;
        }

        public IEnumerable<CandidateDTO> GetAllFormData()
        {
            List<CandidateDTO> listOfCandidates = new List<CandidateDTO>();
            CandidateDTO candidateDTO = new CandidateDTO();

            var allCandidates = _candidateRep.Candidates.GetAll();
            foreach (var item in allCandidates)
            {
                candidateDTO.Id = item.Id;
                candidateDTO.Specialization = item.Specialization;
                candidateDTO.Location = item.Location;
                candidateDTO.EnglishLevel = item.EnglishLevel;
                listOfCandidates.Add(candidateDTO);
            }
            return listOfCandidates;
        }

        public CandidateDTO GetData(int id)
        {
            var candidate = _candidateRep.Candidates.Get(id);
            CandidateDTO candidateDTO = new CandidateDTO();
            candidateDTO.Id = candidate.Id;
            candidateDTO.Location = candidate.Location;
            candidateDTO.Specialization = candidate.Specialization;
            candidateDTO.EnglishLevel = candidate.EnglishLevel;
            
            return candidateDTO;
        }

    }
}
