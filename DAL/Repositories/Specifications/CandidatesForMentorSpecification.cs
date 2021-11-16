using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
    public class CandidatesForMentorSpecification : BaseSpecifications<Candidate>
    {
        public CandidatesForMentorSpecification() : base()
        {
            AddInclude(x => x.CandidateSandboxes);
            SetFilterCondition(x => x.CandidateSandboxes.Where(y => y.SandboxID == 1).Select(x => x.Id).Contains(x.Id));
            SetFilterCondition(x => x.CandidateSandboxes.Where(y => y.SandboxTeams.Where(z => z.TeamID == 3).Select(z => z.CandidateSandboxID).Contains(y.Id)).Select(w => w.CandidateID).Contains(x.Id));
        }
    }
}
