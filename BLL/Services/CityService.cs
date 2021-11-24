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
            var city = _db.Cities.Get(id).CityName;
            var stateId = _db.Cities.Get(id).State_Id;
            var state = _db.States.Get(stateId).StateName;
            var countryId = _db.States.Get(stateId).Country_Id;
            var country = _db.Countries.Get(countryId).CountryName;

            //var countryy = _db.Cities.Get(id).State.Country;
            //var statee = _db.Cities.Get(id).State.StateName;

            string location = $"{country}, {state} , {city}";
            return location;
        }
    }
}
