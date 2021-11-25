using BLL.DTO;
using BLL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SeedExtension
    {
        public static IHost SeedData(this IHost server)
        {
            using (var serviceScope = server.Services.CreateScope())
            {
                SetDefaultSpecialization(serviceScope.ServiceProvider);
                SetDefaultCandidate(serviceScope.ServiceProvider);
            }

            return server;
        }

        private static void SetDefaultSpecialization(IServiceProvider services)
        {
            var unitOfWork = services.GetService<IUnitOfWork>();

            var dotNetSpecialization = new Specialization()
            {
                Name = "dotnet",
                IsActive = false,
            };
            unitOfWork.Specializations.Save(dotNetSpecialization);

            var javaScriptSpecialization = new Specialization()
            {
                Name = "javascript",
                IsActive = false,
            };
            unitOfWork.Specializations.Save(javaScriptSpecialization);

            var usinessAnalystaSpecialization = new Specialization()
            {
                Name = "businessanalyst",
                IsActive = false,
            };
            unitOfWork.Specializations.Save(usinessAnalystaSpecialization);
        }

        //private static Specialization GetSpecialization(string name, IServiceProvider services)
        //{
        //    var unitOfWork = services.GetService<IUnitOfWork>();
        //    unitOfWork.Specializations.Get
        //    return 
        //}

        private static void SetDefaultCandidate(IServiceProvider services)
        {
            var candidateService = services.GetService<ICandidateService>();

            //var idSpecialization = GetSpecialization("dotnet", services);

            var firstCandidateDTO = new CandidateDTO()
            {
                FirstName = "Jack",
                LastName = "Sparrow",
                Email = "jacksparrow@test.com",
                Phone = "+3751231230",
                Skype = "jacksparrow",
                SpecializationID = 1,
                CityID = 3,
                EnglishLevelID = 2,
            };
            candidateService.AddCandidate(firstCandidateDTO);

            var secondCandidateDTO = new CandidateDTO()
            {
                FirstName = "Deyneris",
                LastName = "Targarien",
                Email = "deyneristargarien@test.com",
                Phone = "+3570010209",
                Skype = "deyneristargarien",
                SpecializationID = 1,
                CityID = 3,
                EnglishLevelID = 2,
            };
            candidateService.AddCandidate(secondCandidateDTO);

            var thirdCandidateDTO = new CandidateDTO()
            {
                FirstName = "Klark",
                LastName = "Kent",
                Email = "klarkkent@test.com",
                Phone = "80445677631",
                Skype = "123456fghjk",
                SpecializationID = 1,
                CityID = 3,
                EnglishLevelID = 2,
            };
            candidateService.AddCandidate(thirdCandidateDTO);

            var fourthCandidateDTO = new CandidateDTO()
            {
                FirstName = "Luke",
                LastName = "Skywolker",
                Email = "lukeskywolker@test.com",
                Phone = "88001005001",
                Skype = "lukskyoker",
                SpecializationID = 1,
                CityID = 3,
                EnglishLevelID = 2,
            };
            candidateService.AddCandidate(fourthCandidateDTO);
        }
    }
}
