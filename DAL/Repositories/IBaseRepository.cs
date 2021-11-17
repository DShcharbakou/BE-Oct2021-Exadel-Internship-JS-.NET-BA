using DAL.Models;
using DAL.Repositories.Specifications;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        List<T> GetAll();
        T Get(int id);
        IEnumerable<T> FindWithSpecificationPattern(IBaseSpecifications<T> baseSpecifications = null);
        void Save(T model);
        void Remove(T model);
        void Remove(int id);
    }
}
