using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Country : BaseModel
    {
        public string Shortname { get; set; }
        public string CountryName { get; set; }
        public int Phonecode { get; set; }

        public ICollection<State> States { get; set; }
    }
}
