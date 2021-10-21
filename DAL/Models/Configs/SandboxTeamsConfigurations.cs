using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class SandboxTeamsConfigurations : IEntityTypeConfiguration<SandboxTeam>
    {

        public void Configure(EntityTypeBuilder<SandboxTeam> builder)
        {
            builder.HasOne(x => x.CandidateSandbox)
                .WithMany(x => x.SandboxTeams)
                .HasForeignKey(x => x.CandidateSandboxID);

            builder.HasOne(x => x.InternshipTeam)
                .WithOne(x => x.SandboxTeam);
        }
    }
}