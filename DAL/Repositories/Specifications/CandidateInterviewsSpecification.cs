using DAL.Models;

namespace DAL.Repositories.Specifications
{
    public class CandidateInterviewsSpecification : BaseSpecifications<Candidate>
    {
        public CandidateInterviewsSpecification() : base()
        {
            AddInclude(x => x.Interviews);
        }
    }
}
