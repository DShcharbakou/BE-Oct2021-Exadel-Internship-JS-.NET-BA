using DAL.Models;
using System;
using System.Linq;

namespace DAL.Repositories.Specifications
{
    public class CandidatesForMentorSpecification : BaseSpecifications<Candidate>
    {
        public CandidatesForMentorSpecification(int teamId) : base()
        {
            AddInclude(x => x.CandidateSandboxes);
            SetFilterCondition(x => x.CandidateSandboxes.Where(y => y.Sandbox.StartDate <= DateTimeOffset.UtcNow && y.Sandbox.EndDate >= DateTimeOffset.UtcNow).Select(x => x.Id).Contains(x.Id));
            SetFilterCondition(x => x.CandidateSandboxes.Where(y => y.SandboxTeams.Where(z => z.TeamID == teamId).Select(z => z.CandidateSandboxID).Contains(y.Id)).Select(w => w.CandidateID).Contains(x.Id));
        }
    }
}

