using DAL.Models;
using System;
using System.Linq;

namespace DAL.Repositories.Specifications
{
    public class InternshipSpecification : BaseSpecifications<InternshipTeam>
    {
        public InternshipSpecification(int employeeId) : base()
        {
            AddInclude(x => x.TeamMentors);
            SetFilterCondition(x => x.TeamMentors.Where(e => e.EmployeeID == employeeId).Select(x => x.TeamID).Contains(x.Id));
        }
    }
}