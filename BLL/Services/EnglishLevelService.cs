using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EnglishLevelService : IEnglishLevelService
    {
        private protected IUnitOfWork _db;
        private protected IMapper _mapper;
        public EnglishLevelService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<EnglishLevelDTO> GetAllLevels()
        {
            return _mapper.Map<IEnumerable<EnglishLevel>, List<EnglishLevelDTO>>(_db.EnglishLevels.GetAll().ToList());
        }

        public string GetEnglishLevelById(int id)
        {
            return _db.EnglishLevels.Get(id).LevelName.ToString();
        }
    }
}
