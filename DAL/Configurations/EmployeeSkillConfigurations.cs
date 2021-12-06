using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class EmployeeSkillConfigurations : IEntityTypeConfiguration<EmployeeSkill>
    {

        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeSkills)
                .HasForeignKey(x => x.EmployeeID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Skill)
                .WithMany(x => x.EmployeeSkills)
                .HasForeignKey(x => x.SkillID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(x => new { x.EmployeeID, x.SkillID });
        }
    }
}