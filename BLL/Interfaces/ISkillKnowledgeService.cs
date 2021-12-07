using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface ISkillKnowledgeService
    {
      public void AddSkillKnowledge(IEnumerable<SkillKnowledgeDTO> skillKnowledgeDtoList);
    }
}