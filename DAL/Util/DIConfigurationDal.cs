using DAL.Models;
using DAL.Util;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Util
{
    public class DIConfigurationDal
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // DI need to know about AddTransient, AddSingleton, AddScoped
            services.AddSingleton<BaseRepository<Candidate>, CandidateRepository>();
            services.AddSingleton<BaseRepository<Employee>, EmployeeRepository>();
            services.AddSingleton<BaseRepository<InternshipTeam>, InternshipTeamRepository>();
            services.AddSingleton<BaseRepository<Topic>, TopicRepository>();
        }
    }
}
