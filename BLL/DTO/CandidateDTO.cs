using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CandidateDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public int SpecializationID { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
        public int EnglishLevelID { get; set; }
        public bool? IsInterviewedByHR { get; set; }
        public bool? IsInterviewedByTech { get; set; }
        public string Status { get; set; }
        public int SandboxCount { get; set; }
    }
}
