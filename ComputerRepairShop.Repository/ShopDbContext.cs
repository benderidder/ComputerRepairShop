using ComputerRepairShop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ComputerRepairShop.Repository
{
    public class ShopDbContext : DbContext 
    {
        public DbSet<Device> Devices { get; set; } = null!;

        public string CurrentUserName { get; set; } = string.Empty;

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().ToTable("Device");
        }

        public override int SaveChanges()
        {
            this.SetChangeTrackingProperties();

            return base.SaveChanges();
        }

        private void SetChangeTrackingProperties()
        {
            var trackables = ChangeTracker.Entries<ITrackableEntity>();
            var userName = (string.IsNullOrEmpty(this.CurrentUserName) ? Assembly.GetCallingAssembly().GetName().Name : this.CurrentUserName);

            if (trackables != null)
            {
                // added
                foreach (var item in trackables.Where(t => t.State == EntityState.Added))
                {
                    item.Entity.CreatedOn = DateTime.UtcNow;
                    item.Entity.ModifiedOn = DateTime.UtcNow;

                    if (!string.IsNullOrEmpty(userName))
                    {
                        item.Entity.CreatedBy = item.Entity.CreatedBy ?? userName;
                        item.Entity.ModifiedBy = item.Entity.ModifiedBy ?? userName;
                    }
                }

                // modified
                foreach (var item in trackables.Where(t => t.State == EntityState.Modified))
                {
                    item.Entity.ModifiedOn = DateTime.UtcNow;

                    if (!string.IsNullOrEmpty(userName))
                    {
                        item.Entity.ModifiedBy = item.Entity.ModifiedBy ?? userName;
                    }
                }
            }
        }
    }
}
