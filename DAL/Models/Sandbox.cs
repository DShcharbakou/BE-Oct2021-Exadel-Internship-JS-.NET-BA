using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Sandbox
    {
        public int SandboxID { get; set; }
        public DateTimeOffset Date { get; set; }
        public int EndDate { get; set; }

        public ICollection<CandidateSandbox> CandidateSandboxes { get; set; }
    }
}
