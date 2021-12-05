using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISkillKnowledgeService
    {
      //  IEnumerable<SkillKnowledgeDTO> GetList();
      public void AddSkillKnowledge(IEnumerable<SkillKnowledgeDTO> skillKnowledgeDtoList);
    }
}