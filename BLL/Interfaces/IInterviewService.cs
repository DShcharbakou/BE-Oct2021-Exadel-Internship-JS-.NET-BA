using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
namespace BLL.Interfaces
{
    public interface IInterviewService
    {
        IEnumerable<InterviewDTO> GetList();
        InterviewDTO GetInterviewById(int id);
        void AddInterview(InterviewDTO interviewDto);
        void DeleteInterview(int id);
        int AddHRInterview(HRInterviewDTO hRInterview);
        void SaveCommentForTech(TechSkillsDTO model);
    }
}
