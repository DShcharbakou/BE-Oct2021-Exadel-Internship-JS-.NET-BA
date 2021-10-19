using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CandidateTeam
    {
        public int TeamID { get; set; }
        public int CandidateID { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}
