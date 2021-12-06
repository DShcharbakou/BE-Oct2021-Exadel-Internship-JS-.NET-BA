using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class SpecializationSandboxConfigurations : IEntityTypeConfiguration<SpecializationSandbox>
    {
        public void Configure(EntityTypeBuilder<SpecializationSandbox> builder)
        {
            builder.HasOne(x => x.Sandbox)
                .WithMany(x => x.SpecializationSandboxes)
                .HasForeignKey(x => x.SandboxID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(x => x.Specialization)
                .WithMany(x => x.SpecializationSandboxes)
                .HasForeignKey(x => x.SpecializationID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(x => new { x.SandboxID, x.SpecializationID });
        }
    }
}
