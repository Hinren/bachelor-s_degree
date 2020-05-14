using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignLanguage.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Configuration
{
    class LogExceptionConfiguration : IEntityTypeConfiguration<LogException>
    {
        public void Configure(EntityTypeBuilder<LogException> builder)
        {
            builder.HasKey(e => new { e.LogExceptionId });

            builder.ToTable("LogException");

            builder.Property(e => e.LogExceptionId)
                .HasColumnName("LogExceptionId")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.ExceptionPath)
                .HasColumnName("ExceptionPath")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(e => e.When)
                .HasColumnName("When")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.ExceptionMessage)
               .HasColumnName("ExceptionMessage")
               .HasColumnType("nvarchar(max)")
               .IsRequired();
        }
    }
}
