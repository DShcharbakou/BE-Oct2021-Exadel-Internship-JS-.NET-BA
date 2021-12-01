using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<SpecializationDTO> GetAllSpecialization();
        void SaveSpecialization(List<SpecializationDTO> specialization);
        string GetSpecializationById(int id);
    }
}
