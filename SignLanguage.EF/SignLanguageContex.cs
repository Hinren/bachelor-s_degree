using Microsoft.EntityFrameworkCore;
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
        public DbQuery<GetIdWithMoreThan3BadMeaning> GetIdWithMoreThan3BadMeaning { get; set; }
        public DbQuery<StartQuiz> StartQuiz { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BadMeaningWords>()
                .HasKey(p => p.IdBadMeaningWord);

            modelBuilder.Entity<GoodMeaningWords>()
                .HasKey(p => p.IdGoodMeaningWord);

            modelBuilder.Entity<UsersScoreQuiz>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<LogException>()
                .HasKey(p => p.LogExceptionId);
        }

        public override int SaveChanges()
        {
            var errors = ChangeTracker
               .Entries()
               .Where(e =>  e.State != EntityState.Unchanged)
               .Select(e => e.Metadata.Name)
               .Distinct()
               .ToList();

            if (errors.Any())
            {
                throw new InvalidOperationException(
                    $"Attempted to save read-only entities {string.Join(",", errors)}");
            }

            return base.SaveChanges();
        }
    }
}
