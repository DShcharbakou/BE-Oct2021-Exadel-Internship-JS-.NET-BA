using System.Collections.Generic;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateForm> GetAllCandidateForms();
        CandidateForm GetCandidateFormById(int id);
        void AddCandidate(CandidateForm formData);
        void DeleteCandidate(int id);//type CandidateForm?

    }
}
