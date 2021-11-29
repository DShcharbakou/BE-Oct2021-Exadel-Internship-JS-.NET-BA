using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class InterviewDTO
    {
        public DateTimeOffset Date { get; set; }
        public Candidate Candidate { get; set; }
        public Employee Employee { get; set; }
        public string Comment { get; set; }
    }
}
