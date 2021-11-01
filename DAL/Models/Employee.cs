﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public int RoleId { get; set; }

        public ICollection<Interview> Interviews { get; set; }
        public ICollection<EmployeeStack> EmployeeStack { get; set; }
        public ICollection<TeamMentor> TeamMentors { get; set; }

    }
}
