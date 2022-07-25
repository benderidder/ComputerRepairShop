﻿using ComputerRepairShop.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerRepairShop.Tests
{
    internal class TestHelper
    {
        internal static IServiceProvider Setup()
        {
            var configuration = new ConfigurationBuilder()
                .Build();

            var services = new ServiceCollection()
                .AddServicesForTest(configuration);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            DbInitializer.Initialize(context);

            return serviceProvider;
        }
    }
}
