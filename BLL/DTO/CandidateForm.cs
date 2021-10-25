﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CandidateForm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public string Specialization { get; set; }
        public string Location { get; set; }
        public string EnglishLevel { get; set; }
    }
}
