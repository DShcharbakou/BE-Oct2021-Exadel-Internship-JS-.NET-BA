using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Skill : BaseModel
    {
        public string Description { get; set; }
        public SkillType Type { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<TopicSkill> TopicSkills { get; set; }
    }
}
