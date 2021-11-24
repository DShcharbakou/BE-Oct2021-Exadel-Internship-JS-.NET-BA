using BLL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IUnitOfWork _db;

        public SpecializationService(IUnitOfWork db)
        {
            _db = db;
        }

        public string GetSpecializationById(int id)
        {
            return _db.Specializations.Get(id).Name;
        }
    }
}
