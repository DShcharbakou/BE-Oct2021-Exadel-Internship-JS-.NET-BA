using System.Collections.Generic;
using BLL.DTO;
using DAL.Repositories.Specifications;

namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        List<CandidateDTO> GetAllCandidates();
        CandidateDTO GetCandidateById(int id);
        List<CandidateDTOForGetAll> GetAllCandidatesWithStatuses();
        CandidateDTO GetCandidateByIdWithStatuses(int id);
        void AddCandidate(CandidateDTO formData);
        void DeleteCandidate(int id);
        IEnumerable<CandidateDTO> GetCandidatesFromTeam(int teamId);
        IEnumerable<CandidateDTO> FindCandidates(string textSearch);
        IEnumerable<CandidateDTO> GetAllCandidatesForCurrentTech(EmployeeDTO employee);
    }
}