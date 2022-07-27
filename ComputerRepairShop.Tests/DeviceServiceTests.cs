using ComputerRepairShop.Domain;
using ComputerRepairShop.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ComputerRepairShop.Tests
{
    [TestClass]
    public class DeviceServiceTests
    {
        private IServiceProvider _serviceProvider;
        private IDeviceService _deviceService;

        public DeviceServiceTests()
        {
            _serviceProvider = TestInitializer.Init();
            _deviceService = _serviceProvider.GetRequiredService<IDeviceService>();
        }

        [TestMethod]
        public void TestRetrieveAll()
        {
            var devices = _deviceService.GetDevices();
            Assert.IsNotNull(devices);
        }

        [TestMethod]
        public void TestInsertNew()
        {
            _deviceService.InsertDevice(new Device() { Name = $"IDeviceService: {DateTime.Now}" });
        }

        [TestMethod]
        public void TestGet_DoesNotExist()
        {
            Assert.ThrowsException<ArgumentException>(() => _deviceService.GetDevice(-1));
        }

        [TestMethod]
        public void TestUpdateExisting()
        {
            var device = _deviceService.GetDevices().FirstOrDefault();
            Assert.IsNotNull(device);
            device.Name = $"IDeviceService updated: {DateTime.Now}";
            _deviceService.UpdateDevice(device);
        }
    }
}
