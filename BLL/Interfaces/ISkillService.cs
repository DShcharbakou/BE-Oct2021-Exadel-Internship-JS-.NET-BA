using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<SkillDTO> GetList();
        SkillDTO GetStackById(int id);
        void AddSkill(SkillDTO stackDto);
        void DeleteSkill(int id);
        List<SkillDTO> GetListWithSpec(int candidateId);
    }
}
