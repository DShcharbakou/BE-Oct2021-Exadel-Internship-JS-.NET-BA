using System.Collections.Generic;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateForm> GetAllCandidateForms();
        CandidateForm GetCandidateForm(int id);
        //CandidateDTO GetData(int id);// type Candidate?
        void AddCandidate(CandidateForm formData);

    }
}
