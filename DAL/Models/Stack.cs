﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Stack : BaseModel
    {
        public string Description { get; set; }
        public SkillType Type {get; set; }

        public ICollection<EmployeeStack> EmployeeStacks { get; set; }
        public ICollection<TopicStack> TopicStacks { get; set; }
    }
}
