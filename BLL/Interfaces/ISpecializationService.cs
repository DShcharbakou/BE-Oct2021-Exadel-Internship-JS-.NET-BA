using System.Collections.Generic;
using BLL.DTO;
using DAL.Repositories.Specifications;

namespace BLL.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<SpecializationDTO> GetAllSpecialization();
        void SaveSpecialization(List<SpecializationDTO> specialization);
    }
}
