using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SandboxTeam
    {
        public int TeamID { get; set; }
        public int CandidateSandboxID { get; set; }

        public CandidateSandbox CandidateSandbox { get; set; }
    }
}
