using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Shortname { get; set; }
        public string CountryName { get; set; }
        public int Phonecode { get; set; }
    }
}
