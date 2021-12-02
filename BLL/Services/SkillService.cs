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

        public SkillDTO GetSkillById(int id)
        {
            return _mapper.Map<Skill, SkillDTO>(_db.Skills.Get(id));
        }

        public List<SkillDTO> GetAllSkills(int candidateId)
        {
            var candidate = _db.Candidates.FindWithSpecificationPattern(new CandidateInterviewsSpecification()).FirstOrDefault(x => x.Id == candidateId);
            List<SkillDTO> skillList = new List<SkillDTO>();
            foreach (var interview in candidate.Interviews)
            {
                var interviewDb = _db.Interviews.FindWithSpecificationPattern(new InterviewsLevelsSpecification()).FirstOrDefault(x => x.Id == interview.Id);
                foreach (var skill in interviewDb.SkillKnowledges)
                {
                    SkillDTO skillDTO = new SkillDTO();
                    skillDTO.Description = _db.Skills.Get(skill.SkillID).Description.ToString();
                    skillDTO.Level = skill.Level;
                    skillList.Add(skillDTO);
                }
            }
            return skillList;
        }

        public List<CommentsDTO> GetAllComments(int candidateId)
        {
            var candidate = _db.Candidates.FindWithSpecificationPattern(new CandidateInterviewsSpecification()).FirstOrDefault(x => x.Id == candidateId);
            List<CommentsDTO> commentsList = new List<CommentsDTO>();
            foreach (var interview in candidate.Interviews)
            {
                CommentsDTO comment = new CommentsDTO() { Id = interview.Id, Comment = interview.Comment };
                commentsList.Add(comment);
            }
            return commentsList;
        }

        public List<SkillDTO> GetSoftSkills(int candidateId)
        {
            var candidate = _db.Candidates.FindWithSpecificationPattern(new CandidateInterviewsSpecification()).FirstOrDefault(x => x.Id == candidateId);
            List<SkillDTO> skillList = new List<SkillDTO>();
            foreach (var interview in candidate.Interviews)
            {
                var interviewDb = _db.Interviews.FindWithSpecificationPattern(new InterviewsLevelsSpecification()).FirstOrDefault(x => x.Id == interview.Id);
                foreach (var skill in interviewDb.SkillKnowledges)
                {
                    var skillType = _db.Skills.Get(skill.SkillID);
                    if (skillType.Type == SkillType.SoftSkill)
                    {
                        SkillDTO skillDTO = new SkillDTO();
                        skillDTO.Description = _db.Skills.Get(skill.SkillID).Description.ToString();
                        skillDTO.Level = skill.Level;
                        skillList.Add(skillDTO);
                    }
                }
            }
            return skillList;
        }
    }
}
