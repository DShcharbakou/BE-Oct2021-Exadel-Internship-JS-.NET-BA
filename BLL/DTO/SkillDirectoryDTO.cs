using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SkillDirectoryDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SkillType Type { get; set; }
    }
}
