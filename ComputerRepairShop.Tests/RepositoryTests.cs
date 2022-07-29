using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerRepairShop.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private IServiceProvider _serviceProvider;

        public RepositoryTests()
        {
            _serviceProvider = TestInitializer.Init();
        }

        [TestMethod]
        public void TestInsertNewDevice()
        {
            IRepository<Device> repository = _serviceProvider.GetRequiredService<IRepository<Device>>();

            repository.Insert(new Device() { Name = "Test new device" });
        }

        [TestMethod]
        public void TestInsertNewServiceOrder()
        {
            var repository = _serviceProvider.GetRequiredService<IRepository<DeviceServiceOrder>>();
            var testName = "Test new service order";

            repository.Insert(
                new DeviceServiceOrder()
                {
                    Device = new Device() { Name = testName },
                    ServiceOrder = new ServiceOrder() { Name = testName, IntakeDate = DateTime.Now }
                });
        }
    }
}