using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class InterviewResult
    {
        public int InterviewID {get; set;}
        public int TopicID {get; set;}
        public int Level {get; set;}
        public string Comment {get; set;}
    }
}
