using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignLanguage.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Configuration
{
    class ActivityOnWebsiteConfiguration : IEntityTypeConfiguration<ActivityOnWebsite>
    {
        public void Configure(EntityTypeBuilder<ActivityOnWebsite> builder)
        {
            builder.HasKey(e => new { e.ActivityOnWebsiteId });

            builder.ToTable("ActivityOnWebsite");

            builder.Property(e => e.ActivityOnWebsiteId)
                .HasColumnName("ActivityOnWebsiteId")
                .IsRequired();

            builder.Property(e => e.Controller)
                .HasColumnName("Controller")
                .IsRequired();

            builder.Property(e => e.ActionName)
                .HasColumnName("Action")
                .IsRequired();

            builder.Property(e => e.httpTypeAction)
               .HasColumnName("httpTypeAction")
               .IsRequired();

            builder.Property(e => e.Userid)
               .HasColumnName("Userid")
               .IsRequired();

            builder.Property(e => e.When)
               .HasColumnName("When")
               .IsRequired();
        }
    }
}
