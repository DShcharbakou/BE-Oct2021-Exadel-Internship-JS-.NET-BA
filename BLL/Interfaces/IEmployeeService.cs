using System.Collections.Generic;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetList();
        EmployeeDTO GetEmployeeById(int id);
        void DeleteEmployee(int id);
        EmployeeDTO GetEmployeeByEmail(string email);
    }
}
