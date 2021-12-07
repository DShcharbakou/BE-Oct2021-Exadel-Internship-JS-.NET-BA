using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class CityConfigurations : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(x => x.State)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.State_Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
