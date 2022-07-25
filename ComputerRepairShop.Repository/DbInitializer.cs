using ComputerRepairShop.Domain;

namespace ComputerRepairShop.Repository
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.Devices.Any())
            {
                return;
            }

            var Devices = new Device[]
            {
                new Device() { Name = "Laptop 1" }
            };

            context.Devices.AddRange(Devices);

            context.SaveChanges();
        }
    }
}
