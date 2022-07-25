using ComputerRepairShop.Domain;
using ComputerRepairShop.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerRepairShop.Tests
{
    [TestClass]
    public class DeviceServiceTests
    {
        private IServiceProvider _serviceProvider;

        public DeviceServiceTests()
        {
            _serviceProvider = TestHelper.Setup();
        }

        [TestMethod]
        public void TestSaveNew()
        {
            IDeviceService service = _serviceProvider.GetRequiredService<IDeviceService>();

            service.InsertDevice(new Device() { Name = $"IDeviceService: {DateTime.Now}" });
        }
    }
}
