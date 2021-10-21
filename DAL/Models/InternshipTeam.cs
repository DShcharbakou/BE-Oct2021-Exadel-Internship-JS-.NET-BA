using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class InternshipTeam : BaseModel
    {
        public int TeamNumber { get; set; }

        public SandboxTeam SandboxTeam { get; set; }
        public TeamMentor TeamMentor { get; set; }
    }
}
