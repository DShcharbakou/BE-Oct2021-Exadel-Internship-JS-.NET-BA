using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SkillKnowledge
    {
        public int InterviewID {get; set;}
        public int SkillID {get; set;}
        public int Level {get; set;}
        public string Comment {get; set;}

        public Interview Interview { get; set; }
        public Skill Skill { get; set; }
    }
}
