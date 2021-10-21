using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    internal class StackRepository : BaseRepository<Stack>
    {
        public StackRepository(InternshipDbContext internshipDbContext) : base(internshipDbContext) { }
    }
}