using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
   public class StatusForCandidateSpecification : BaseSpecifications<Status>
    {
        public StatusForCandidateSpecification(int candidateId) : base()
        {
                AddInclude(x => x.CandidateSandboxes);
                SetFilterCondition(x => x.CandidateSandboxes.Where(y => y.Sandbox.StartDate <= DateTime.UtcNow && y.Sandbox.EndDate >= DateTime.UtcNow && y.CandidateID == candidateId).Select(x => x.StatusID).Contains(x.Id));
        }

        
    }

    public class CandidatesWithStatusesSpecification : BaseSpecifications<CandidateSandbox>
    {
        public CandidatesWithStatusesSpecification(int? candidateId) : base()
        {
            AddInclude(x => x.Candidate.Interviews);
            AddInclude(x => x.Status);
            AddInclude(x => x.Sandbox);
            //AddInclude(x => x.Sandbox);
            SetFilterCondition(x => x.Sandbox.StartDate <= DateTime.UtcNow && x.Sandbox.EndDate >= DateTime.UtcNow);
            if (candidateId.HasValue)
            {
                SetFilterCondition(x => x.Status.CandidateSandboxes.Where(y => y.CandidateID == candidateId).Select(x => x.StatusID).Contains(x.Id));
                //need to have status name
                SetFilterCondition(x => x.Sandbox.CandidateSandboxes.Where(y => y.CandidateID == candidateId).Select(x => x.Id).Contains(x.Id));
                // need to count this number
                SetFilterCondition(x => x.Candidate.Interviews.Where(y => y.CandidateID == candidateId).Select(z => z.Id).Contains(x.Id));
                // need to count this number
            }
        }
    }
}
