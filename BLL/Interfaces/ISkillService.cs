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
        SkillDTO GetSkillById(int id);
        IEnumerable<SkillDTO> GetList();
        void AddSkill(SkillDTO skillDto);
        void DeleteSkill(int id);
        List<SkillDTO> GetListWithSpec(int candidateId);
        List<CommentsDTO> GetAllComments(int candidateId);
    }
}
