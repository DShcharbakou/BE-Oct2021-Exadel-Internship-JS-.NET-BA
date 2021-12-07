using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SpecializationSandbox
    {
        public int SandboxID { get; set; }
        public int SpecializationID { get; set; }
        public Sandbox Sandbox { get; set; }
        public Specialization Specialization { get; set; }
    }
}
