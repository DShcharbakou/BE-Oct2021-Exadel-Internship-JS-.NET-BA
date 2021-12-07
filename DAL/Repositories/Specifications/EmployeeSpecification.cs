using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Specifications
{
    public class EmployeeSpecification : BaseSpecifications<Interview>
    {
        public EmployeeSpecification() : base()
        {
            AddInclude(x => x.Employee);
            AddInclude(x => x.Employee.Interviews);
        }
    }
}
