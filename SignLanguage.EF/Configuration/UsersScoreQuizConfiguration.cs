using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Configuration
{
    class UsersScoreQuizConfiguration : IEntityTypeConfiguration<UsersScoreQuiz>
    {
        public void Configure(EntityTypeBuilder<UsersScoreQuiz> builder)
        {
            builder.HasKey(e => new { e.Id });

            builder.ToTable("UsersScoreQuiz");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.IdUser)
                .HasColumnName("IdUser")
                .IsRequired();

            builder.Property(e => e.HowManyQuestions)
                .HasColumnName("HowManyQustion")
                .IsRequired();

            builder.Property(e => e.HowManyCorrect)
                .HasColumnName("EffectivenessInPercent")
                .IsRequired();
        }
    }
}
