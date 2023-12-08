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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
