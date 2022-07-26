using ComputerRepairShop.Repository;

namespace ComputerRepairShop.WebAPI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            var data = serviceProvider.GetRequiredService<ShopDbContext>();

            ShopDbInitializer.Initialize(data);

            return app;
        }
    }
}
