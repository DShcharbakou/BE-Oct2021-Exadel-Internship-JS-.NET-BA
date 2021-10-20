﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    class CandidateConfigurations : IEntityTypeConfiguration<Candidate>
    {

        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasMany(x => x.Interviews)
                .WithOne(x => x.Candidate);

            builder.HasMany(x => x.CandidateSandbox)
                .WithOne(x => x.Candidates);
        }
    }
}
