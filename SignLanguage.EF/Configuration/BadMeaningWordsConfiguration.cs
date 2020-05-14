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
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.IdGoodMeaningWord)
                .HasColumnName("IdGoodMeaningWord")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Meaning)
                .HasColumnName("Meaning")
                .HasColumnType("nvarchar(50)")
                .IsRequired();
        }
    }
}
