using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class TeamsMentorConfigurations : IEntityTypeConfiguration<TeamMentor>
    {

        public void Configure(EntityTypeBuilder<TeamMentor> builder)
        {
            builder.HasOne(x => x.InternshipTeam)
                .WithMany(x => x.TeamMentors)
                .HasForeignKey(x => x.EmployeeID);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.TeamMentors)
                .HasForeignKey(x => x.EmployeeID);

            builder.HasKey(x => new { x.EmployeeID, x.TeamID });
        }
    }
}
