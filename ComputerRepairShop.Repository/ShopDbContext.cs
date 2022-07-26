using ComputerRepairShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepairShop.Repository
{
    public class ShopDbContext : DbContext 
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().ToTable("Device");
        }
    }
}
