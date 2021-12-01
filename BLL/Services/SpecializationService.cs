using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Data;

namespace BLL.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public SpecializationService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public IEnumerable<SpecializationDTO> GetAllSpecialization()
        {
            return _mapper.Map<IEnumerable<Specialization>, List<SpecializationDTO>>(_db.Specializations.GetAll());
        }

        public void SaveSpecialization(List<SpecializationDTO> specializationsDto)
        {
            _db.Specializations.RemoveAll();
            var specializations = new List<Specialization>();
            foreach (var specializationDto in specializationsDto)
            {
                specializations.Add(_mapper.Map<Specialization>(specializationDto));
            }

            _db.Specializations.BulkSave(specializations);
            _db.Save();
        }

        public string GetSpecializationById(int id)
        {
            return _db.Specializations.Get(id).Name;
        }
    }
}
