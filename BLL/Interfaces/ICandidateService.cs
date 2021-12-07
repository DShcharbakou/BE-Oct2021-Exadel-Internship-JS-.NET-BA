using System.Collections.Generic;
using BLL.DTO;
using DAL.Models;
using DAL.Repositories.Specifications;

namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        List<CandidateDTO> GetAllCandidates();
        CandidateDTO GetCandidateById(int id);
        Candidate GetCandidateDALById(int candidateId);
        List<CandidateDTOForGetAll> GetAllCandidatesWithStatuses();
        CandidateDTO GetCandidateByIdWithStatuses(int? id);
        int AddCandidate(CandidateDTO formData);
        void SaveCV(AddFileDTO model);
        string GetDocumentUrl(int candidateId);
        void DeleteCandidate(int id);
        IEnumerable<CandidateDTO> GetCandidatesFromTeam(int teamId);
        IEnumerable<CandidateDTO> FindCandidates(string textSearch);
        IEnumerable<CandidateDTO> GetAllCandidatesForCurrentTech(EmployeeDTO employee);
    }
}