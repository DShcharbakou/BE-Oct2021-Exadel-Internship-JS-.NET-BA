using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
  public class InterviewStatusSpecification : BaseSpecifications<Interview>
    {
        public InterviewStatusSpecification (): base()
        {
            AddInclude(x => x.Candidate.CandidateSandboxes);
        }
    }
}
