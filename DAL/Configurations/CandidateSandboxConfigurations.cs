using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class CandidateSandboxConfigurations : IEntityTypeConfiguration<CandidateSandbox>
    {

        public void Configure(EntityTypeBuilder<CandidateSandbox> builder)
        {
            builder.HasOne(x => x.Candidate)
                .WithMany(x => x.CandidateSandboxes)
                .HasForeignKey(x => x.CandidateID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Sandbox)
                .WithMany(x => x.CandidateSandboxes)
                .HasForeignKey(x => x.SandboxID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Status)
            .WithMany(x => x.CandidateSandboxes)
            .HasForeignKey(x => x.StatusID)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
