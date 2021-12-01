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

        public string GetLocationById(int id)
        {
            var city = _db.Cities.Get(id);
            var state = _db.States.Get(city.State_Id);
            var country = _db.Countries.Get(state.Country_Id);
            return $"{country.CountryName}, {state.StateName}, {city.CityName}";
        }
    }
}
