using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CandidateSandbox : BaseModel
    {

        public int CandidateSandboxID { get; set; } // I think if we have inheritance from BaseModel we don't need CandidateSandboxID
        public int CandidateID { get; set; }
        public int SandboxID { get; set; }
        public bool IsActive { get; set; }

        public Candidate Candidate { get; set; }
        public Sandbox Sandbox { get; set; }

        public ICollection<SandboxTeam> SandboxTeams { get; set; }
    }
}
