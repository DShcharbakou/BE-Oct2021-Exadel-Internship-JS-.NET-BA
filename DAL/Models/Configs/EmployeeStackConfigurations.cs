using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class EmployeeStackConfigurations : IEntityTypeConfiguration<EmployeeStack>
    {

        public void Configure(EntityTypeBuilder<EmployeeStack> builder)
        {
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeStack)
                .HasForeignKey(x => x.EmployeeID);

            builder.HasOne(x => x.Stack)
                .WithMany(x => x.EmployeeStacks)
                .HasForeignKey(x => x.StackID);
        }
    }
}