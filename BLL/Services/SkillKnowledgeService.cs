using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SkillKnowledgeService : ISkillKnowledgeService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public SkillKnowledgeService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
      /*  public void AddSkillKnowledge(SkillKnowledgeDTO skillKnowledgeDto)
        {
            var skill = _mapper.Map<SkillKnowledge>(skillKnowledgeDto);
            _db.SkillKnowledges.Save(skillKnowledgeDto);
            _db.Save();
        }

        public IEnumerable<SkillKnowledgeDTO> GetList()
        {
            return _mapper.Map<IEnumerable<SkillKnowledge>, List<SkillKnowledgeDTO>>(_db.SkillKnowledges.GetAll());
        }     
      */
    }
}
