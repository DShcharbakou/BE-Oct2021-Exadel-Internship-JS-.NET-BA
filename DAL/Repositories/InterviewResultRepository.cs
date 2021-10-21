using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    internal class InterviewResultsRepository : BaseRepository<InterviewResult>
    {
        public InterviewResultsRepository(InternshipDbContext internshipDbContext) : base(internshipDbContext) { }
    }
}