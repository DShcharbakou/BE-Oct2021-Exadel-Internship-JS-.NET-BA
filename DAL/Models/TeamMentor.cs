using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class TeamMentor : BaseModel
    {
        public int TeamID { get; set; }
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }
        public InternshipTeam InternshipTeam { get; set; }
    }
}
