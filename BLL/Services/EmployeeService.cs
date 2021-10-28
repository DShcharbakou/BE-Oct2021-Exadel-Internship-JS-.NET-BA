using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL;
using DAL.Models;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _employeeRep;

        public EmployeeService(IUnitOfWork emp)
        {
            _employeeRep = emp;
        }

        public IEnumerable<EmployeeDTO> GetList()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(_employeeRep.Employees.GetAll());
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<Employee, EmployeeDTO>(_employeeRep.Employees.Get(id));
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRep.Employees.Get(id);
            _employeeRep.Employees.Remove(employee);
            _employeeRep.Save();
        }
    }
}