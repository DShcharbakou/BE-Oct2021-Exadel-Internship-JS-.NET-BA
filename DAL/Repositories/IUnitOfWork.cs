using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Candidate> Candidates { get; }
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<InternshipTeam> InternshipTeams { get; }
        IBaseRepository<Interview> Interviews { get; }
        IBaseRepository<Skill> Skills { get; }
        IBaseRepository<Topic> Topics { get; }
        IBaseRepository<Specialization> Specializations { get; }
        IBaseRepository<EnglishLevel> EnglishLevels { get; }
        IBaseRepository<Country> Countries { get; }
        IBaseRepository<State> States { get; }
        IBaseRepository<City> Cities { get; }
        IBaseRepository<CandidateSandbox> CandidatesSandboxes { get; }
        IBaseRepository<Sandbox> Sandboxes { get; }
        IBaseRepository<Status> Statuses { get; }

        void Save();
    }
}