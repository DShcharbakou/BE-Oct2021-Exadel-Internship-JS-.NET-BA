using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    internal class EmployeeStackRepository : BaseRepository<EmployeeStack>
    {
        public EmployeeStackRepository(InternshipDbContext internshipDbContext) : base(internshipDbContext) { }
    }
}