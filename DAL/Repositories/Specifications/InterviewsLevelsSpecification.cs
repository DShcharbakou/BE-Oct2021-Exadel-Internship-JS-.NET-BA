using DAL.Models;


namespace DAL.Repositories.Specifications
{
    public class InterviewsLevelsSpecification : BaseSpecifications<Interview>
    {
        public InterviewsLevelsSpecification() : base()
        {
            AddInclude(x => x.SkillKnowledges);
        }
    }
}
