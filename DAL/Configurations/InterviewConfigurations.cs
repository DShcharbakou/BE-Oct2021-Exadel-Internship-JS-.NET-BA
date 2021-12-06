using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class InterviewConfigurations : IEntityTypeConfiguration<Interview>
    {

        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasOne(x => x.Candidate)
                .WithMany(x => x.Interviews)
                .HasForeignKey(x => x.CandidateID)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Interviews)
                .HasForeignKey(x => x.EmployeeID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
