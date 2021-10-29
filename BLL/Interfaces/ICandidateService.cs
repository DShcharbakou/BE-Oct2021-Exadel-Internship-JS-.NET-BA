using System.Collections.Generic;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateDTO> GetAllCandidates();
        CandidateDTO GetCandidateById(int id);
        void AddCandidate(CandidateDTO formData);
        void DeleteCandidate(int id);

    }
}
