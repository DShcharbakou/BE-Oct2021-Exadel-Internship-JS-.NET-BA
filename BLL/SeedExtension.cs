using BLL.DTO;
using BLL.Interfaces;
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
                SetDefaultCandidate(serviceScope.ServiceProvider);
            }

            return server;
        }

        private static void SetDefaultCandidate(IServiceProvider services)
        {
            var candidateService = services.GetService<ICandidateService>();

            var firstCandidateDTO = new CandidateDTO()
            {
                FirstName = "Jack",
                LastName = "Sparrow",
                Email = "mailto:jacksparrow@test.com",
                Phone = "+3751231230",
                Skype = "jacksparrow",
                SpecializationID = 1,
                CityID = 3,
                EnglishLevelID = 2,
            };
            candidateService.AddCandidate(firstCandidateDTO);
        }
    }
}
