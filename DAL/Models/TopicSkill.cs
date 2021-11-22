using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TopicSkill
    {
        public int TopicID {get; set;}
        public int SkillID { get; set;}

        public Skill Skill { get; set; }
        public Topic Topic { get; set; }
    }
}
