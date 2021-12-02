using DAL.Models;
using System.Linq;

namespace DAL.Repositories.Specifications
{
    public class CountrySpecification : BaseSpecifications<Country>
    {
        public CountrySpecification(int countryId) : base()
        {
            AddInclude(x => x.States);
            SetFilterCondition(x => x.States.Where(x => x.Country_Id == countryId).Select(x => x.Id).Contains(x.Id));
        }
    }
}
