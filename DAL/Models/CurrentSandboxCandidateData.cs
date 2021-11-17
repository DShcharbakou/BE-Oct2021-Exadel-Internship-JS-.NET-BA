using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
 public  class CurrentSandboxCandidateData : BaseModel
    {
        public int CandidateID { get; set; }
        public int SandboxID { get; set; }
        public int StatusID { get; set; }
    }
}
