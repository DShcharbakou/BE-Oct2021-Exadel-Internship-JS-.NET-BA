using DAL.Models;
using DAL.Repositories.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        T Get(int id);
        IQueryable<T> FindWithSpecificationPattern(IBaseSpecifications<T> baseSpecifications = null);
        void Save(T model);
        void BulkSave(IList<T> model);
        void RemoveAll();
        void Remove(T model);
        void Remove(int id);
    }
}
