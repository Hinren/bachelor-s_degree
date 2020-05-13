using Microsoft.EntityFrameworkCore;
using SignLanguage.EF.Configuration;
using SignLanguage.EF.Models;
using System;
using System.Linq;

namespace SignLanguage.EF
{
    public class SignLanguageContex : DbContext
    {
        public SignLanguageContex()
        {
        }

        public SignLanguageContex(DbContextOptions<SignLanguageContex> options)
       : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<BadMeaningWords> BadMeaningWords { get; set; }
        public DbSet<GoodMeaningWords> GoodMeaningWords { get; set; }
        public DbSet<UsersScoreQuiz> UsersScoreQuiz { get; set; }
        public DbSet<LogException> LogExceptions { get; set; }
        public DbSet<ActivityOnWebsite> ActivityOnWebsites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActivityOnWebsiteConfiguration());
            modelBuilder.ApplyConfiguration(new BadMeaningWordsConfiguration());
            modelBuilder.ApplyConfiguration(new GoodMeaningWordsConfigurations());
            modelBuilder.ApplyConfiguration(new LogExceptionConfiguration());
            modelBuilder.ApplyConfiguration(new UsersScoreQuizConfiguration());
        }
    }
}
