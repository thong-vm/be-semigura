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

        public DbSet<Models.File> Files => Set<Models.File>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Delivery> Deliverys => base.Set<Delivery>();
        public DbSet<Product> Products => base.Set<Product>();
        public DbSet<Truck> Trucks => base.Set<Truck>();
        public DbSet<Area> Areas => base.Set<Area>();
        public DbSet<Moromi> Moromis => base.Set<Moromi>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
