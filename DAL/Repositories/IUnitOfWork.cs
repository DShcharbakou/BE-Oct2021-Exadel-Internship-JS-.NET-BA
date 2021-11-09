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
        BaseRepository<Candidate> Candidates { get; }
        BaseRepository<Employee> Employees { get; }
        BaseRepository<InternshipTeam> InternshipTeams { get; }
        BaseRepository<Interview> Interviews { get; }
        BaseRepository<Skill> Skills { get; }
        BaseRepository<Topic> Topics { get; }
        BaseRepository<Specialization> Specializations{get;}
        BaseRepository<EnglishLevel> EnglishLevels {get;}
        BaseRepository<Country> Countries{ get; }
        BaseRepository<City> Cities { get; }
void Save();
    }
}
