﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    internal class TopicStackRepository : BaseRepository<TopicStack>
    {
        public TopicStackRepository(InternshipDbContext internshipDbContext) : base(internshipDbContext) { }
    }
}