using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class HRInterviewResults
    {
        public int EmployeeID { get; set; }
        public DateTimeOffset DateOfInterview { get; set; }
        public int CandidateID { get; set; }
        public int EnglishLevelMark { get; set; }
        public int CommunicationSkillsMark { get; set; }
        public int AbilityToListenMark { get; set; }
        public int SelfConfidenceMark { get; set; }
        public string Comment { get; set; }
    }
}
