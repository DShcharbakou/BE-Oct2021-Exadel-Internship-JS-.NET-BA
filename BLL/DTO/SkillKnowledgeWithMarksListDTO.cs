using System.Collections.Generic;

namespace BLL.DTO
{
    public class SkillKnowledgeWithMarksListDTO
    {
        public int? InterviewID { get; set; }
        public List<InterviewMarksWithSkillIDDTO> MarksList{get; set;}
    }
}