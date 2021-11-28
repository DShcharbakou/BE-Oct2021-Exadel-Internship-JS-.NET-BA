using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
  public class HRInterviewDTO
    {
        public int EmployeeID { get; set; } //maybe I need to get this value from token
        public DateTimeOffset DateOfInterview { get; set; }
        public int CandidateID { get; set; }
        public int EnglishLevel { get; set; }
        public int CommunicationSkills { get; set; }
        public int AbilityToListen { get; set; }
        public int SelfConfidence { get; set; }
        public string Comment { get; set; }
    }
}
