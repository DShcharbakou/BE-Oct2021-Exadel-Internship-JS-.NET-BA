﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
   public class CandidateForHRSpecification : BaseSpecifications<Candidate>
    {
        public CandidateForHRSpecification() : base()
        {
            AddInclude(x => x.CandidateSandboxes);
            //filtration by current sandbox
            SetFilterCondition(x => x.CandidateSandboxes.Where(y => y.Sandbox.StartDate <= DateTime.UtcNow && y.Sandbox.EndDate >= DateTime.UtcNow).Select(x => x.Id).Contains(x.Id));
            
        }
    }
}
