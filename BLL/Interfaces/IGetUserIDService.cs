using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IGetUserIDService
    {
        public EmployeeDTO GetEmployeeByEmail(string email);
    }
}
