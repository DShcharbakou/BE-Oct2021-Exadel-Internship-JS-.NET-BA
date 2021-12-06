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
        public void AddSkillKnowledge(IEnumerable<SkillKnowledgeDTO> skillKnowledgeDtoList)
        {
            foreach (var skillKnowledgeDto in skillKnowledgeDtoList)
            {
                var skillKnowledge = _mapper.Map<SkillKnowledge>(skillKnowledgeDto);
                var interview = _db.Interviews.FindWithSpecificationPattern(new InterviewsLevelsSpecification()).FirstOrDefault(x => x.Id == skillKnowledgeDto.InterviewID);
                var temInterv = interview.SkillKnowledges.FirstOrDefault(x => x.SkillID == skillKnowledgeDto.SkillID);
                if (temInterv != null)
                {
                    temInterv.Level = skillKnowledgeDto.Level;
                }
                else
                {
                    interview.SkillKnowledges.Add(skillKnowledge);
                }
                _db.Interviews.Save(interview);
                _db.Save();
            }
        }


        /* 
                public IEnumerable<SkillKnowledgeDTO> GetList()
                {
                    return _mapper.Map<IEnumerable<SkillKnowledge>, List<SkillKnowledgeDTO>>(_db.SkillKnowledges.GetAll());
                }     
              */
    }
}
