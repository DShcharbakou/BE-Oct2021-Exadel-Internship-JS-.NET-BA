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
}
