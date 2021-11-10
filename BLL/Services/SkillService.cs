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
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public SkillService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void AddSkill(SkillDTO skillDto)
        {
            var skill = _mapper.Map<Skill>(skillDto);
            _db.Skills.Save(skill);
            _db.Save();
        }

        public void DeleteSkill(int id)
        {
            var skill = _db.Skills.Get(id);
            _db.Skills.Remove(skill);
            _db.Save();
        }

        public IEnumerable<SkillDTO> GetList()
        {
            return _mapper.Map<IEnumerable<Skill>, List<SkillDTO>>(_db.Skills.GetAll());
        }

        public SkillDTO GetStackById(int id)
        {
            return _mapper.Map<Skill, SkillDTO>(_db.Skills.Get(id));
        }
    }
}
