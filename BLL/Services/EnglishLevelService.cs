using BLL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EnglishLevelService : IEnglishLevelService
    {
        private protected IUnitOfWork _db;

        public EnglishLevelService(IUnitOfWork db)
        {
            _db = db;
        }

        public string GetEnglishLevelById(int id)
        {
            return _db.EnglishLevels.Get(id).LevelName.ToString();
        }
    }
}
