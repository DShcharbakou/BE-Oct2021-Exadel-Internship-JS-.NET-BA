using Microsoft.Extensions.DependencyInjection;
using DAL.Util;
using BLL.Interfaces;
using BLL.Services;
using BLL.MappingProfiles;
using AutoMapper;
namespace BLL.Util
{
    public class DIConfigurationBll
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // DI need to know about AddTransient, AddSingleton, AddScoped
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IInternshipTeamService, InternshipTeamService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IInterviewService, InterviewService>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            DIConfigurationDal.ConfigureServices(services);
        }
    }
}
