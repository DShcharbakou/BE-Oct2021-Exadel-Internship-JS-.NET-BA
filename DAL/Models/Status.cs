﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public  class Status : BaseModel
    {
        public string Name { get; set; }

        public ICollection<CandidateSandbox> CandidateSandboxes { get; set; }
    }
}
