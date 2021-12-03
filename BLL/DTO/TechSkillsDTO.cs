using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TechSkillsDTO
    {
        public int CandidateId { get; set; }
        public string TechComment { get; set; }
        public List<SkillDTO> TechSkillsList { get; set; }
    }
}
