using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Util
{
    public class DIConfigurationDal
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // DI need to know about AddTransient, AddSingleton, AddScoped
            services.AddTransient<BaseRepository<Candidate>, CandidateSet>();
            services.AddTransient<BaseRepository<Employee>, EmployeeRepository>();
            services.AddTransient<BaseRepository<InternshipTeam>, InternshipTeamRepository>();
            services.AddTransient<BaseRepository<Topic>, TopicRepository>();
            services.AddTransient<BaseRepository<Interview>, InterviewRepository>();
            services.AddTransient<BaseRepository<Stack>, StackRepository>();
        }
    }
}
