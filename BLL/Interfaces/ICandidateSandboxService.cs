using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICandidateSandboxService
    {
        IEnumerable<CandidateSandboxDTO> GetList();
        CandidateSandboxDTO GetCandidateSandboxById(int id);
        void AddGradeAndComment(CandidateSandboxDTO dto);

        public void SetStatusAfterHrInterview(HRInterviewDTOWithStatus hrInterviewDTODecline);

        CandidateSandboxDTO GetCandidateSandboxByCandidateId(int candidateId);
        public void AddCandidateSandbox(CandidateDTO candidateDto);
        public void SetStatus(CandidateDTO candidateDto, int statusID);
    }
}
