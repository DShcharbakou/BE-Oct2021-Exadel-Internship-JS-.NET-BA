using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class TopicStackConfigurations : IEntityTypeConfiguration<TopicStack>
    {

        public void Configure(EntityTypeBuilder<TopicStack> builder)
        {
            builder.HasOne(x => x.Topic)
                .WithMany(x => x.TopicStacks)
                .HasForeignKey(x => x.TopicID);
        }
    }
}
