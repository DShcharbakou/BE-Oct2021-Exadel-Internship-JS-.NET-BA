﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Candidate : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public string Specialization { get; set; }
        public string Location { get; set; }
        public string EnglishLevel { get; set; }
        public DateTimeOffset RegDate { get; set; }
        public bool IsArchived { get; set; }

        public ICollection<Interview> Interviews { get; set; }

        public ICollection<CandidateSandbox> CandidateSandboxes { get; set; }
    }
}
