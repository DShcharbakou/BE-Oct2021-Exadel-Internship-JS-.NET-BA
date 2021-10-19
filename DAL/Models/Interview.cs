using System;

namespace DAL
{
    public class Interview
    {
        public int InterviewID { get; set; }
        public int CandidateID { get; set; }
        public int EmployeeID { get; set; }
        public DateTimeOffset Date { get; set; }

        public Candidate Candidate { get; set; }
        public Employee Employee{ get; set; }
    }
}
