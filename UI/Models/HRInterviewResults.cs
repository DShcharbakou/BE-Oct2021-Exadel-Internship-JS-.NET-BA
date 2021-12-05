using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class HRInterviewResults
    {
        public DateTimeOffset DateOfInterview { get; set; }
        public int CandidateID { get; set; }
        public List<InterviewMarksWithSkillID> Marks { get; set; }
        public string Comment { get; set; }
    }
}
