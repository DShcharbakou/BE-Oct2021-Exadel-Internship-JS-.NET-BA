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
        }
    }
}
