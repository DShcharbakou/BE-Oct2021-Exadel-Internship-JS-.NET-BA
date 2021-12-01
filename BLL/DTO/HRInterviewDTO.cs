using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
  public class HRInterviewDTO
    {
        public int? ID { get; set; }
        public int EmployeeID { get; set; }
        public DateTimeOffset DateOfInterview { get; set; }
        public int CandidateID { get; set; }
        public List<InterviewMarksWithSkillIDDTO> Marks { get; set; }
        public string Comment { get; set; }
    }
}
