using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CandidateSandboxForSetDTO
    {
        public int CandidateID { get; set; }
        public int? SandboxID { get; set; }
        public int? StatusID {get; set;}
        public int? Grade { get; set; }
        public string Comment { get; set; }
    }
}
