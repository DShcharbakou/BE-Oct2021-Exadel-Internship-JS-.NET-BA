using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IUnitOfWork _db;

        public SpecializationService(IUnitOfWork db)
        {
            _db = db;
        }

        public string GetSpecializationById(int id)
        {
            return _db.Specializations.Get(id).Name.ToString();
        }
    }
}
