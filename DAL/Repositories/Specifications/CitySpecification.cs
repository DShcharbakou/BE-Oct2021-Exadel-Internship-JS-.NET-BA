using DAL.Models;
using System.Linq;

namespace DAL.Repositories.Specifications
{
    public class CitySpecification : BaseSpecifications<City>
    {
        public CitySpecification() : base()
        {
            AddInclude(x => x.State);
            AddInclude(x => x.State.Country);
        }
    }
}
