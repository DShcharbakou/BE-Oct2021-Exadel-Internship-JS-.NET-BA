﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class CandidateSet : BaseRepository<Candidate>
    {
        public CandidateSet(InternshipDbContext internshipDbContext) : base(internshipDbContext) { }

    }
}
