using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using ComputerRepairShop.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerRepairShop.Tests
{
    internal static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServicesForTest(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = "Server=(localdb)\\mssqllocaldb;Database=ComputerRepairStore;Trusted_Connection=True;MultipleActiveResultSets=true";

            services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString, opt => opt.EnableRetryOnFailure()), ServiceLifetime.Transient)
                .AddScoped<IRepository<Device>, Repository<Device>>()
                .AddScoped<IDeviceService, DeviceService>();

            return services;
        }
    }
}
