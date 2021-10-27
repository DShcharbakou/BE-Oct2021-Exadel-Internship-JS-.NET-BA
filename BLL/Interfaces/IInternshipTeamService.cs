using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IInternshipTeamService
    {
        IEnumerable<InternshipTeamDTO> GetList();//возвращать InternshipTeam или InternshipTeamDTO?
        InternshipTeamDTO GetInternshipTeamById(int id);
        void AddInternshipTeam(InternshipTeamDTO teamDto);
        void DeleteInternshipTeam(int id);
    }
}
