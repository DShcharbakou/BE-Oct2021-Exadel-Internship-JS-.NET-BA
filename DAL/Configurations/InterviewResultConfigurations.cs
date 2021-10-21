using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class InterviewResultConfigurations : IEntityTypeConfiguration<InterviewResult>
    {

        public void Configure(EntityTypeBuilder<InterviewResult> builder)
        {
            builder.HasOne(x => x.Interview)
                .WithMany(x => x.InterviewResults)
                .HasForeignKey(x => x.InterviewID);

            builder.HasOne(x => x.Topics)
                .WithMany(x => x.InterviewResults)
                .HasForeignKey( x => x.TopicID);
        }
    }
}
