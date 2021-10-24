using System.Collections.Generic;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<CandidateDTO> GetAllFormData(); // specialization, location, englishlevel
        CandidateDTO GetData(int id);// type Candidate?
    }
}
