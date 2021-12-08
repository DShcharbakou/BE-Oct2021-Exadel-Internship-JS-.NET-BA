using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
   public class SandboxForCandidateSandboxSpecification: BaseSpecifications<Sandbox>
    {
        public SandboxForCandidateSandboxSpecification() : base()
        {
            SetFilterCondition(x => x.StartDate <= DateTime.UtcNow && x.EndDate >= DateTime.UtcNow);
        }
    }
}
