using Microsoft.EntityFrameworkCore;
using MoviesManagement.Core.Domain.Entities;

namespace MoviesManagement.Infrastructure.Persistence
{
    internal class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaCompany> CinemaCompanies { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<CinemaCompany>()
                 .HasMany(c => c.Movies)
                 .WithOne(m => m.CinemaCompany!)
                 .HasForeignKey(m => m.CinemaCompanyId);

            modelBuilder
                .Entity<Movie>()
                .HasOne(m => m.CinemaCompany)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CinemaCompanyId);
        }
    }
}
