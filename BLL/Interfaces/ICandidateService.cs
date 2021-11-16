using System.Collections.Generic;
using BLL.DTO;
using DAL.Repositories.Specifications;

namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateDTO> GetAllCandidates();
        CandidateDTO GetCandidateById(int id);
        void AddCandidate(CandidateDTO formData);
        void DeleteCandidate(int id);
        IEnumerable<CandidateDTO> GetCandidatesFromTeam();
    }
}
