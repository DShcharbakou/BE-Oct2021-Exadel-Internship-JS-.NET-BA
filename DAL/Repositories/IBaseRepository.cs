using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        List<T> GetAll();
    }
}