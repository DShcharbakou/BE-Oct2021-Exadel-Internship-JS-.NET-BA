using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class TopicStackConfigurations : IEntityTypeConfiguration<TopicStack>
    {

        public void Configure(EntityTypeBuilder<TopicStack> builder)
        {
            builder.HasOne(x => x.Topic)
                .WithMany(x => x.TopicStacks)
                .HasForeignKey(x => x.TopicID);

            builder.HasOne(x => x.Stack)
                .WithMany(x => x.TopicStacks)
                .HasForeignKey(x => x.StackID);

            builder.HasKey(x => new { x.StackID, x.TopicID });
        }
    }
}
