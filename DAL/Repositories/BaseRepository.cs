using DAL.Models;
using DAL.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly InternshipDbContext _internshipDbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(InternshipDbContext internshipDbContext)
        {
            _internshipDbContext = internshipDbContext;
            _dbSet = _internshipDbContext.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T Get(int id)
        {
            return _dbSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> FindWithSpecificationPattern(IBaseSpecifications<T> baseSpecifications = null)
        {
                return  _internshipDbContext.Set<T>().AsNoTracking().ToList();
        }

        public virtual void Save(T model)
        {
            if (model.Id > 0)
            {
                _dbSet.Update(model);
            }
            else
            {
                _dbSet.Add(model);
            }
        }

        public virtual void Remove(T model)
        {
            _internshipDbContext.Remove(model);
        }

        public virtual void Remove(int id)
        {
            var model = Get(id);
            Remove(model);
        }

        //public virtual void Remove(List<long> ids)
        //{
        //    foreach (var id in ids)
        //    {
        //        Remove(id);
        //    }
        //}
    }

}