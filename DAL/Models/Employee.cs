﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Emails { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public int RoleId { get; set; }

    }
}
