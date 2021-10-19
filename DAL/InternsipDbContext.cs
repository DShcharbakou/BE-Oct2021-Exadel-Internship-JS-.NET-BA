using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class InternsipDbContext : DbContext
    {
        public InternsipDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Candidate> Candidates { get; set; }

    }
}
