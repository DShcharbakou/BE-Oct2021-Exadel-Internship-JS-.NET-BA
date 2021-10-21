using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class CandidateSandboxConfigurations : IEntityTypeConfiguration<CandidateSandbox>
    {

        public void Configure(EntityTypeBuilder<CandidateSandbox> builder)
        {
            builder.HasOne(x => x.Candidates)
                .WithMany(x => x.CandidateSandbox)
                .HasForeignKey(x => x.CandidateID);

            builder.HasOne(x => x.Sandbox)
                .WithMany(x => x.CandidateSandboxes)
                .HasForeignKey(x => x.SandboxID);
        }
    }
}
