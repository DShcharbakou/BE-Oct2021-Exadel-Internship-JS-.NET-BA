using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CandidateSandbox
    {
        public int CandidateSandboxID { get; set; }
        public int CandidateID { get; set; }
        public int SandboxID { get; set; }
        public bool IsActive { get; set; }

        public Candidate Candidate { get; set; }
        public Sandbox Sandbox { get; set; }

        public ICollection<SandboxTeam> SandboxTeams { get; set; }
    }
}
