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
            // arange and act
            var devices = _deviceService.GetAllDevices();
            
            // assert
            Assert.IsNotNull(devices);
        }

        [TestMethod]
        public void TestInsertNew()
        {
            _deviceService.SaveDevice(new Device() { Name = $"Test: {DateTime.Now}" });
        }

        [TestMethod]
        public void TestGet_DoesNotExist()
        {
            Assert.ThrowsException<ArgumentException>(() => _deviceService.GetDevice(-1));
        }

        [TestMethod]
        public void TestUpdateExisting()
        {
            // arange
            var device = _deviceService.GetAllDevices().FirstOrDefault(new Device() { Name = $"Test: {DateTime.Now}" });
            device.Name = $"Test updated: {DateTime.Now}";

            // act
            _deviceService.SaveDevice(device);
        }
    }
}
