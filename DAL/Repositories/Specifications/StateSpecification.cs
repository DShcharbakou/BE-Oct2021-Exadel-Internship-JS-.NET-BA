using DAL.Models;
using System.Linq;

namespace DAL.Repositories.Specifications
{
    public class StateSpecification : BaseSpecifications<State>
    {
        public StateSpecification(int stateId) : base()
        {
            AddInclude(x => x.Cities);
            SetFilterCondition(x => x.Cities.Where(x => x.State_Id == stateId).Select(x => x.Id).Contains(x.Id));
        }
    }
}
