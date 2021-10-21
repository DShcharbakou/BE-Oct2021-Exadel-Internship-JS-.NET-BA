﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class CandidateSandboxConfiguration : IEntityTypeConfiguration<CandidateSandbox>
    {

        public void Configure(EntityTypeBuilder<CandidateSandbox> builder)
        {
            builder.HasOne(x => x.Sandbox)
                .WithMany(x => x.CandidateSandboxes)
                .HasForeignKey(x => x.SandboxID);

            builder.HasMany(x => x.SandboxTeams)
                .WithOne(x => x.CandidateSandbox)
                .HasForeignKey(x => x.TeamID);
        }
    }
}