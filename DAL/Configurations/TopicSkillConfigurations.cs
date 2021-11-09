using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class TopicSkillConfigurations : IEntityTypeConfiguration<TopicSkill>
    {

        public void Configure(EntityTypeBuilder<TopicSkill> builder)
        {
            builder.HasOne(x => x.Topic)
                .WithMany(x => x.TopicSkills)
                .HasForeignKey(x => x.TopicID);

            builder.HasOne(x => x.Skill)
                .WithMany(x => x.TopicSkills)
                .HasForeignKey(x => x.SkillID);

            builder.HasKey(x => new { x.SkillID, x.TopicID });
        }
    }
}
