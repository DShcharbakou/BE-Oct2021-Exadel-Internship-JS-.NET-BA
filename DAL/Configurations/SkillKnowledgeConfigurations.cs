using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class SkillKnowledgeConfigurations : IEntityTypeConfiguration<SkillKnowledge>
    {
        public void Configure(EntityTypeBuilder<SkillKnowledge> builder)
        {
            builder.HasOne(x => x.Interview)
                .WithMany(x => x.SkillKnowledges)
                .HasForeignKey(x => x.InterviewID)
                .OnDelete(DeleteBehavior.NoAction); ;

            builder.HasOne(x => x.Skill)
                .WithMany(x => x.SkillKnowledges)
                .HasForeignKey( x => x.SkillID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasKey(x => new { x.InterviewID, x.SkillID });
        }
    }
}
