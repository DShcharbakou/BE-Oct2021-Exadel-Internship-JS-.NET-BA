using System.Collections.Generic;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetList();//возвращать employee или EmployeeDTO?
        EmployeeDTO GetEmployeeById(int id);//возвращать employee или EmployeeDTO?
        void DeleteEmployee(int id);//type EmployeeDTO int?
    }
}
