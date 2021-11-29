using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class GetUserIDService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public GetUserIDService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public EmployeeDTO GetEmployeeByEmail(string email)
        {
            return _mapper.Map<Employee, EmployeeDTO>(_db.Employees.GetAll().Where(x => x.Email == email).FirstOrDefault());
        }
    }
}
