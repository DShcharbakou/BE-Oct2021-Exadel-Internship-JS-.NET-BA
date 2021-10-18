using System;

namespace DAL
{
    public class HrInterview
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ScaleScore { get; set; }
        public string Feedback { get; set; }
        public int EnglishLevel { get; set; }

        //public List<Candidates> CandidateId 
        //public List<Employees> EmployeeId 
    }
}
