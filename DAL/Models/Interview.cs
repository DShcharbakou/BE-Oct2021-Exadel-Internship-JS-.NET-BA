using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Interview : BaseModel
    {
        public int CandidateID { get; set; }
        public int EmployeeID { get; set; }
        public DateTimeOffset Date { get; set; }

        public Candidate Candidate { get; set; }
        public Employee Employee{ get; set; }

        public ICollection<SkillKnowledge> SkillKnowledges { get; set; }
    }
}
