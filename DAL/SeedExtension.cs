using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SeedExtension
    {
        //private static readonly UserManager<User> _userManager;

        //public static IHost SeedData(this IHost server)
        //{
        //    //SeedAdmin();
        //    //using (var serviceScope = server.Services.CreateScope())
        //    //{
        //    //    //SetAdmin(serviceScope.ServiceProvider);
        //    //}

        //    //return server;
        //}

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "admin", "recruiter", "manager", "interviewer", "mentor", "supermentor" };

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static void SeedAdmin(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("admin@tut.by").Result == null)
            {
                User user = new User
                {
                    UserName = "admin@tut.by",
                    Email = "admin@tut.by",
                    FirstName = "Ad",
                    LastName = "min",
                    Password = "Test1!"
                };

                IdentityResult result = userManager.CreateAsync(user, "Test1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "admin").Wait();

                }
            }
        }


    }

    //private static void SetAdmin(IServiceProvider services)
    //{
    //    //var userRepository = services.GetService<IUserRepository>();
    //    var test = services.GetService<IUnitOfWork>();
    //    var userRepository = services.GetService<RegisterService>();

    //    User admin = new User { Email = "admin@tut.by", UserName = "admin@tut.by", FirstName = "Ad", LastName = "min", Password = "Test1!" };


    //    //var admin = userRepository.Get(AdminName);
    //    //if (admin == null)
    //    //{
    //    //    admin = new User()
    //    //    {
    //    //        Login = AdminName,
    //    //        Name = AdminName,
    //    //        Password = "123",
    //    //        Age = 100,
    //    //        JobType = JobType.Admin
    //    //    };
    //    //    userRepository.Save(admin);
    //    //}

    //    //var chiefBankEmployee = userRepository.Get("chiefBankEmployee");
    //    //if (chiefBankEmployee == null)
    //    //{
    //    //    chiefBankEmployee = new User()
    //    //    {
    //    //        Login = "ChiefBankEmployee",
    //    //        Name = "ChiefBankEmployee",
    //    //        Password = "123",
    //    //        Age = 100,
    //    //        JobType = JobType.ChiefBankEmployee
    //    //    };
    //    //    userRepository.Save(chiefBankEmployee);
    //    //}
    //}
}
