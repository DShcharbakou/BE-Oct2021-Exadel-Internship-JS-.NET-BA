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
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IInternshipTeamService, InternshipTeamService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IInterviewService, InterviewService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISandboxService, SandboxService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<IEnglishLevelService, EnglishLevelService>();
            services.AddScoped<ICityService, CityService>();
            DIConfigurationDal.ConfigureServices(services);
        }
    }
}
