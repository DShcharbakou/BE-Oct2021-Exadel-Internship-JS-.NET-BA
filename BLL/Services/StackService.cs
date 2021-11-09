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
    public class StackService : IStackService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public StackService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void AddStack(StackDTO stackDto)
        {
            var stack = _mapper.Map<Skill>(stackDto);
            _db.Skills.Save(stack);
            _db.Save();
        }

        public void DeleteStack(int id)
        {
            var stack = _db.Skills.Get(id);
            _db.Skills.Remove(stack);
            _db.Save();
        }

        public IEnumerable<StackDTO> GetList()
        {
            return _mapper.Map<IEnumerable<Skill>, List<StackDTO>>(_db.Skills.GetAll());
        }

        public StackDTO GetStackById(int id)
        {
            return _mapper.Map<Skill, StackDTO>(_db.Skills.Get(id));
        }
    }
}
