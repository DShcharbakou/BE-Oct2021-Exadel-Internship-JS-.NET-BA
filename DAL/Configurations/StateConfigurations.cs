using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class StateConfigurations : IEntityTypeConfiguration<State>
    {

        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasOne(x => x.Country)
                .WithMany(x => x.States)
                .HasForeignKey(x => x.Country_Id);
        }
    }
}
