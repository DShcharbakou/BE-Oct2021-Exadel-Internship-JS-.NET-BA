using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Topic : BaseModel
    {
        public string Description {get; set;}

        public ICollection<TopicSkill> TopicSkills { get; set; }
    }
}
