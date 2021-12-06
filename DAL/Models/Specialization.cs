using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Specialization : BaseModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SpecializationSandbox> specializationSandboxes { get; set; }
    }
}
