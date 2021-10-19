using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Stack : BaseModel
    {
        public int StackID { get; set; }
        public string Description { get; set; }
    }
}
