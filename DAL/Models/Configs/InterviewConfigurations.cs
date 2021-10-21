using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class InterviewConfigurations : IEntityTypeConfiguration<Interview>
    {

        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.HasOne(x => x.Candidate)
                .WithMany(x => x.Interviews)
                .HasForeignKey(x => x.CandidateID);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Interviews)
                .HasForeignKey(x => x.EmployeeID);
        }
    }
}
