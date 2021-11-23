using System.Collections.Generic;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL;
using System.Linq;

namespace BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDTO> GetList()
        {
            return _mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(_db.Employees.GetAll());
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _mapper.Map<Employee, EmployeeDTO>(_db.Employees.Get(id));
        }

        public void DeleteEmployee(int id)
        {
            var employee = _db.Employees.Get(id);
            _db.Employees.Remove(employee);
            _db.Save();
        }

        public EmployeeDTO GetEmployeeByEmail(string email)
        {
            return _mapper.Map<Employee, EmployeeDTO>(_db.Employees.GetAll().Where(x => x.Email == email).FirstOrDefault());
        }
    }
}