using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeStack
    {
        public int EmployeeID { get; set;}
        public int StackID {get; set;}

        public ICollection<Employee> Employee { get; set; }
        //public Stack Stack { get; set; }
    }
}
