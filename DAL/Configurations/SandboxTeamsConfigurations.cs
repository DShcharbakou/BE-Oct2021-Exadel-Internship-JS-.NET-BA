using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class SandboxTeamsConfigurations : IEntityTypeConfiguration<SandboxTeam>
    {

        public void Configure(EntityTypeBuilder<SandboxTeam> builder)
        {
            builder.HasOne(x => x.CandidateSandbox)
                .WithMany(x => x.SandboxTeams)
                .HasForeignKey(x => x.CandidateSandboxID);

            builder.HasOne(x => x.InternshipTeam)
                .WithMany(x => x.SandboxTeams)
                .HasForeignKey(x => x.TeamID);

            builder.HasKey(x => new { x.TeamID, x.CandidateSandboxID});
        }
    }
}