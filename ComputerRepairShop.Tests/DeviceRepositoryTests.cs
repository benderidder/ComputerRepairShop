using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerRepairShop.Tests
{
    [TestClass]
    public class DeviceRepositoryTests
    {
        private IServiceProvider _serviceProvider;

        public DeviceRepositoryTests()
        {
            _serviceProvider = TestHelper.Setup();
        }

        [TestMethod]
        public void TestSaveNew()
        {
            IRepository<Device> repository = _serviceProvider.GetRequiredService<IRepository<Device>>();

            repository.Insert(new Device() { Name = $"IRepository<Device>: {DateTime.Now}" });
        }
    }
}