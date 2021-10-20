using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class StackConfigurations : IEntityTypeConfiguration<Stack>
    {

        public void Configure(EntityTypeBuilder<Stack> builder)
        {
            builder.HasMany(x => x.TopicStacks)
                .WithOne(x => x.Stack);
        }
    }
}
