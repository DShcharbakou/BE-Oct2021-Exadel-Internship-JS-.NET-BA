using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Sandbox : BaseModel
    {
       
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        public ICollection<CandidateSandbox> CandidateSandboxes { get; set; }
    }
}
