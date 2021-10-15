using System;

namespace DAL
{
    public class HrInterview
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ScaleScore { get; set; }
        public string FeedBack { get; set; }
        public int EnglishLevel { get; set; }

        //public List<Candidates> CandidateId 
        //public List<Employees> EmployeeId 
    }
}
