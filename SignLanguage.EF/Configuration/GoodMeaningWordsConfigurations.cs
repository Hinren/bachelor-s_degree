using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Configuration
{
    class GoodMeaningWordsConfigurations : IEntityTypeConfiguration<GoodMeaningWords>
    {
        public void Configure(EntityTypeBuilder<GoodMeaningWords> builder)
        {
            builder.HasKey(e => new { e.IdGoodMeaningWord});

            builder.ToTable("GoodMeaningWords");

            builder.Property(e => e.IdGoodMeaningWord)
                .HasColumnName("IdGoodMeaningWord")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Meaning)
                .HasColumnName("Meaning")
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(e => e.Url)
                .HasColumnName("Url")
                .HasColumnType("nchar(300)")
                .IsRequired();
        }
    }
}
