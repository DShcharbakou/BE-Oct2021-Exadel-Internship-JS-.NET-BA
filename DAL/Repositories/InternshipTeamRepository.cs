﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    internal class InternshipTeamRepository : BaseRepository<InternshipTeam>
    {
        public InternshipTeamRepository(InternshipDbContext internshipDbContext) : base(internshipDbContext) { }
    }
}