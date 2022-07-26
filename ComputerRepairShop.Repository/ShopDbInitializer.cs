using ComputerRepairShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComputerRepairShop.Repository
{
    public static class ShopDbInitializer
    {
        public static void Initialize(ShopDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
