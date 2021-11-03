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
    public static class StartupSeedExtension
    {
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

        public static void SeedUsers(UserManager<User> userManager)
        {
            List<User> users = new List<User>() { };

            User admin = new User
            {
                UserName = "admin@exadel.com",
                Email = "admin@exadel.com",
                FirstName = "Admin",
                LastName = "Admin",
                Password = "Admin1!"
            };
            users.Add(admin);

            User recruiterVasya = new User
            {
                UserName = "recruiterVasya@exadel.com",
                Email = "recruiterVasya@exadel.com",
                FirstName = "Vasya",
                LastName = "Vasylyev",
                Password = "RecruiterVasya1!"
            };
            users.Add(recruiterVasya);

            User recruiterPetya = new User
            {
                UserName = "recruiterPetya@exadel.com",
                Email = "recruiterPetya@exadel.com",
                FirstName = "Petya",
                LastName = "Petrov",
                Password = "RecruiterPetya1!"
            };
            users.Add(recruiterPetya);

            User managerLesha = new User
            {
                UserName = "managerLesha@exadel.com",
                Email = "managerLesha@exadel.com",
                FirstName = "Lesha",
                LastName = "Leshov",
                Password = "ManagerLesha1!"
            };
            users.Add(managerLesha);

            User managerKatya = new User
            {
                UserName = "managerKatya@exadel.com",
                Email = "managerKatya@exadel.com",
                FirstName = "Katya",
                LastName = "Kotova",
                Password = "ManagerKatya1!"
            };
            users.Add(managerKatya);

            User interviewerDima = new User
            {
                UserName = "interviewerDima@exadel.com",
                Email = "interviewerDima@exadel.com",
                FirstName = "Dima",
                LastName = "Dimov",
                Password = "InterviewerDima1!"
            };
            users.Add(interviewerDima);

            User interviewerKostya = new User
            {
                UserName = "interviewerKostya@exadel.com",
                Email = "interviewerKostya@exadel.com",
                FirstName = "Kostya",
                LastName = "Kostov",
                Password = "InterviewerKostya1!"
            };
            users.Add(interviewerKostya);

            User mentorSasha = new User
            {
                UserName = "mentorSasha@exadel.com",
                Email = "mentorSasha@exadel.com",
                FirstName = "Sasha",
                LastName = "Sashov",
                Password = "MentorSasha1!"
            };
            users.Add(mentorSasha);

            User mentorVadim = new User
            {
                UserName = "mentorVadim@exadel.com",
                Email = "mentorVadim@exadel.com",
                FirstName = "Vadim",
                LastName = "Vodov",
                Password = "MentorVadim1!"
            };
            users.Add(mentorVadim);

            User supermentorKirill = new User
            {
                UserName = "supermentorKirill@exadel.com",
                Email = "supermentorKirill@exadel.com",
                FirstName = "Kirill",
                LastName = "Kirillov",
                Password = "SupermentorKirill1!"
            };
            users.Add(supermentorKirill);

            User supermentorLena = new User
            {
                UserName = "supermentorLena@exadel.com",
                Email = "supermentorLena@exadel.com",
                FirstName = "Lena",
                LastName = "Lenova",
                Password = "SupermentorLena1!"
            };
            users.Add(supermentorLena);

            foreach (var user in users)
            {
                if (userManager.FindByEmailAsync(user.Email).Result == null)
                {
                    IdentityResult resultCreating = userManager.CreateAsync(user, user.Password).Result;
                    if (resultCreating.Succeeded) { continue; }
                }
            }

            userManager.AddToRoleAsync(admin, "admin").Wait();
            userManager.AddToRoleAsync(recruiterVasya, "recruiter").Wait();
            userManager.AddToRoleAsync(recruiterPetya, "recruiter").Wait();
            userManager.AddToRoleAsync(managerLesha, "manager").Wait();
            userManager.AddToRoleAsync(managerKatya, "manager").Wait();
            userManager.AddToRoleAsync(interviewerDima, "interviewer").Wait();
            userManager.AddToRoleAsync(interviewerKostya, "interviewer").Wait();
            userManager.AddToRoleAsync(mentorSasha, "mentor").Wait();
            userManager.AddToRoleAsync(mentorVadim, "mentor").Wait();
            userManager.AddToRoleAsync(supermentorKirill, "supermentor").Wait();
            userManager.AddToRoleAsync(supermentorLena, "supermentor").Wait();
        }
    }
}
