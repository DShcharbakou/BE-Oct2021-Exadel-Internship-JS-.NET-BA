using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class InterviewResultConfigurations : IEntityTypeConfiguration<InterviewResult>
    {

        public void Configure(EntityTypeBuilder<InterviewResult> builder)
        {
            builder.HasOne(x => x.Interview)
                .WithMany(x => x.InterviewResults);

            builder.HasMany(x => x.Topics)
                .WithMany(x => x.InterviewResults);
        }
    }
}
