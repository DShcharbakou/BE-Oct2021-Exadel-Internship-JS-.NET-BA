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
                .HasForeignKey(x => x.InterviewID);

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.SkillKnowledges)
                .HasForeignKey( x => x.TopicID);

            builder.HasKey(x => new { x.InterviewID, x.TopicID });
        }
    }
}
