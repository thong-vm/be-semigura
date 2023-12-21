using Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Factory> Factories => base.Set<Factory>();
        public DbSet<Container> Containers => base.Set<Container>();
        public DbSet<be_semigura.Models.Location> Locations => base.Set<be_semigura.Models.Location>();
        public DbSet<Lot> Lots => base.Set<Lot>();
        public DbSet<LotContainer> LotContainers => base.Set<LotContainer>();
        public DbSet<LotContainerTerminal> LotContainerTerminals => base.Set<LotContainerTerminal>();
        public DbSet<SensorData> SensorDatas => base.Set<SensorData>();
        public DbSet<Terminal> Terminals => base.Set<Terminal>();
        public DbSet<Material> Materials => base.Set<Material>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorData>().HasOne(sd => sd.Terminal).WithMany(t => t.SensorDatas).HasForeignKey(sd => sd.TerminalId);
            modelBuilder.Entity<SensorData>().HasOne(sd => sd.LotContainer).WithMany(lc => lc.SensorDatas).HasForeignKey(sd => sd.LotContainerId);
            modelBuilder.Entity<LotContainer>().HasOne(lc => lc.Lot).WithMany(l => l.LotContainers).HasForeignKey(lc => lc.LotId);
            modelBuilder.Entity<LotContainer>().HasOne(lc => lc.Location).WithMany(l => l.LotContainers).HasForeignKey(l => l.LocationId);
            modelBuilder.Entity<LotContainer>().HasOne(lc => lc.Container).WithMany(l => l.LotContainers).HasForeignKey(c => c.ContainerId);
            modelBuilder.Entity<Lot>().HasOne(l => l.Factory).WithMany(f => f.Lots).HasForeignKey(l => l.FactoryId);
            modelBuilder.Entity<be_semigura.Models.Location>().HasOne(l => l.Factory).WithMany(f => f.Locations).HasForeignKey(l => l.FactoryId);
            modelBuilder.Entity<LotContainerTerminal>().HasOne(lct => lct.LotContainer).WithMany(lc => lc.LotContainerTerminals).HasForeignKey(lct => lct.LotContainerId);
            modelBuilder.Entity<LotContainerTerminal>().HasOne(lct => lct.Terminal).WithMany(t => t.LotContainerTerminals).HasForeignKey(lct => lct.TerminalId);
            modelBuilder.Entity<Container>().HasOne(c => c.Location).WithMany(l => l.Containers).HasForeignKey(c => c.LocationId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditProperties();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            SetAuditProperties();
            return base.SaveChanges();
        }

        private void SetAuditProperties()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is AuditableEntityBase &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (AuditableEntityBase)entityEntry.Entity;
                string currentUserId = "currentUserId";
                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                    entity.CreatedById = currentUserId;
                }
                entity.ModifiedOn = DateTime.UtcNow;
                entity.ModifiedById = currentUserId;
            }
        }
    }

}
