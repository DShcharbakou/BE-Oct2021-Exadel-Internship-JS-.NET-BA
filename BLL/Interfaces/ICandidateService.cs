﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface ICandidateService
    {
        IEnumerable<Candidate> GetFormData(); // specialization, location, englishlevel
        
    }
}
