using BLL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CityService : ICityService
    {
        private protected IUnitOfWork _db;

        public CityService(IUnitOfWork db)
        {
            _db = db;
        }

        public string GetCityById(int id)
        {
            var city = _db.Cities.Get(id).ToString();
            var countryId = _db.Cities.Get(id).CountryID;
            var country = _db.Countries.Get(countryId).ToString();
            string location = $"{city}, {country}";
            return location;
        }
    }
}
