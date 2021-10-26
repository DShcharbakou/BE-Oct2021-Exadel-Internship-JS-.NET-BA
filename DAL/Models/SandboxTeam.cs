using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SandboxTeam
    {
        public int TeamID { get; set; }
        public int CandidateSandboxID { get; set; }

        public CandidateSandbox CandidateSandbox { get; set; }
        public InternshipTeam InternshipTeam { get; set; }
    }
}
