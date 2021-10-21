using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IntershipTeam
    {
        public int ID { get; set; }
        public int TeamNumber { get; set; }

        public SandboxTeam SandboxTeam { get; set; }
        public TeamMentor TeamMentor { get; set; }
    }
}
