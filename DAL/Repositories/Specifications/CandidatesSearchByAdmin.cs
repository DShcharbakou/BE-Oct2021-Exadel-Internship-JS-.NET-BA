using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
    public class CandidatesSearchByAdmin : BaseSpecifications<Candidate>
    {
        public CandidatesSearchByAdmin(string textSearch) : base()
        {
            SetFilterCondition(y => y.FirstName.Contains(textSearch) || y.LastName.Contains(textSearch) || y.Email.Contains(textSearch));
        }
    }
}

