using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class IntershipTeamsConfigurations : IEntityTypeConfiguration<IntershipTeam>
    {

        public void Configure(EntityTypeBuilder<IntershipTeam> builder)
        {
            builder.HasOne(x => x.TeamMentor)
                .WithOne(x => x.IntershipTeam)
                .HasForeignKey( x => x)

            builder.HasOne(x => x.SandboxTeam)
                .WithOne(x => x.IntershipTeam);
        }
    }
}