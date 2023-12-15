using be_semigura.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Moromi> Moromis => base.Set<Moromi>();
        public DbSet<Batch> Batches => base.Set<Batch>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Batch>()
            .HasKey(b => b.Id);

            modelBuilder.Entity<Moromi>()
                .HasOne(m => m.Batch)
                .WithMany(b => b.Moromis)
                .HasForeignKey(m => m.BatchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
