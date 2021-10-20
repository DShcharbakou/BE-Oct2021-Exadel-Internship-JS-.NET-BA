using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasMany(x => x.EmployeeStack)
                .WithOne(x => x.Employee);

            builder.HasMany(x => x.Interviews)
                .WithOne(x => x.Employee);

            builder.HasMany(x => x.TeamMentors)
                .WithOne(x => x.Employee);
        }
    }
}
