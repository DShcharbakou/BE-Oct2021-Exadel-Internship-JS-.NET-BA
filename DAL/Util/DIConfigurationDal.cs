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

            services.AddTransient<IBaseRepository<Candidate>, BaseRepository<Candidate>>();
            services.AddTransient<IBaseRepository<Employee>, BaseRepository<Employee>>();
            services.AddTransient<IBaseRepository<InternshipTeam>, BaseRepository<InternshipTeam>>();
            services.AddTransient<IBaseRepository<Topic>, BaseRepository<Topic>>();
            services.AddTransient<IBaseRepository<Interview>, BaseRepository<Interview>>();
            services.AddTransient<IBaseRepository<Skill>, BaseRepository<Skill>>();
        }
    }
}
