using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Util
{
    public class DIConfigurationDal
    {
        public static void ConfigureServices(IServiceCollection services)
        {
             //DI need to know about AddTransient, AddSingleton, AddScoped
            services.AddScoped<IUnitOfWork, UnitOfWork>(); 
            services.AddScoped<IBaseRepository<Candidate>, BaseRepository<Candidate>>();
            services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<IBaseRepository<InternshipTeam>, BaseRepository<InternshipTeam>>();
            services.AddScoped<IBaseRepository<Topic>, BaseRepository<Topic>>();
            services.AddScoped<IBaseRepository<Interview>, BaseRepository<Interview>>();
            services.AddScoped<IBaseRepository<Skill>, BaseRepository<Skill>>();
            services.AddScoped<IBaseRepository<CandidateSandbox>, BaseRepository<CandidateSandbox>>();
        }
    }
}
