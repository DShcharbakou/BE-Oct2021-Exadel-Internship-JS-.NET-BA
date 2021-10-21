using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class TeamsMentorConfigurations : IEntityTypeConfiguration<TeamMentor>
    {

        public void Configure(EntityTypeBuilder<TeamMentor> builder)
        {
            builder.HasOne(x => x.IntershipTeam)
                .WithOne(x => x.TeamMentor);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.TeamMentors)
                .HasForeignKey(x => x.EmployeeID);
        }
    }
}
