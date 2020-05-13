using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Configuration
{
    class BadMeaningWordsConfiguration : IEntityTypeConfiguration<BadMeaningWords>
    {
        public void Configure(EntityTypeBuilder<BadMeaningWords> builder)
        {
            builder.HasKey(e => new { e.IdBadMeaningWord });

            builder.ToTable("BadMeaningWords");

            builder.Property(e => e.IdBadMeaningWord)
                .HasColumnName("IdBadMeaningWord")
                .IsRequired();

            builder.Property(e => e.IdGoodMeaningWord)
                .HasColumnName("IdGoodMeaningWord")
                .IsRequired();

            builder.Property(e => e.Meaning)
                .HasColumnName("Meaning")
                .IsRequired();
        }
    }
}
