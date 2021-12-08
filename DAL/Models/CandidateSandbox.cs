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
        public int CandidateID { get; set; }
        public int SandboxID { get; set; }
        public int? StatusID { get; set; }
        public int? Grade { get; set; }
        public string Comment { get; set; }
        public Candidate Candidate { get; set; }
        public Sandbox Sandbox { get; set; }
        public Status Status { get; set; }

        public ICollection<SandboxTeam> SandboxTeams { get; set; }
    }
}
