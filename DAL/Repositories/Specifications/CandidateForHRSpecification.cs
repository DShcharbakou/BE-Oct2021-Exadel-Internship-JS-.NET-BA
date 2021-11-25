using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
   public class CandidateForHRSpecification : BaseSpecifications<CandidateSandbox>
    {
        public CandidateForHRSpecification(int? candidateId) : base()
        {
                AddInclude(x => x.Candidate);
                AddInclude(x => x.Candidate.Interviews);
                AddInclude(x => x.Status);
                AddInclude(x => x.Sandbox);
                SetFilterCondition(x => x.Sandbox.StartDate <= DateTime.UtcNow && x.Sandbox.EndDate >= DateTime.UtcNow);
            if (candidateId.HasValue)
            {
                SetFilterCondition(x => x.CandidateID == candidateId);
            }
        }

   }
}
    