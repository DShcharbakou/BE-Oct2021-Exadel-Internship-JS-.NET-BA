﻿using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        List<T> GetAll();
        T Get(int id);
        void Save(T model);
        void Remove(T model);
        void Remove(int id);
    }
}