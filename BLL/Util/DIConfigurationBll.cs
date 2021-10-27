using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Util;
using DAL.Repositories;
using BLL.Interfaces;
using BLL.Services;

namespace BLL.Util
{
    public class DIConfigurationBll
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // DI need to know about AddTransient, AddSingleton, AddScoped
            services.AddTransient<ICandidateService, CandidateService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IInternshipTeamService, InternshipTeamService>();
            DIConfigurationDal.ConfigureServices(services);
        }
    }
}
