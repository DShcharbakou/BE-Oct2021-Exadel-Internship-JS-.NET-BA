using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CandidateForMentorDTO: CandidateDTO
    {
        public string Specialization { get; set; }
        public string Location { get; set; }
        public string EnglishLevel { get; set; }
    }
}
