using System;

namespace DAL.Models
{
    public class Interview : BaseModel
    {
        public int InterviewID { get; set; }
        public int CandidateID { get; set; }
        public int EmployeeID { get; set; }
        public DateTimeOffset Date { get; set; }

        //public List<Candidates> CandidateId 
        //public List<Employees> EmployeeId 
    }
}
