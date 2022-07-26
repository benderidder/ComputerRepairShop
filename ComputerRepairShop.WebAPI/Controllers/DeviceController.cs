using ComputerRepairShop.Domain;
using ComputerRepairShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepairShop.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDeviceService _deviceService;

        public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        [HttpGet("", Name = "GetDevices")]
        public IEnumerable<Device> GetAll()
        {
            IEnumerable<Device> devices = _deviceService.GetDevices();

            return devices;
        }

        [HttpGet("first", Name = "GetFirstDevice")]
        public Device GetFirst()
        {
            IEnumerable<Device> devices = _deviceService.GetDevices();
            Device device = new Device();
            if(devices.Any())
            {
                device = devices.ToList()[0];
            }
            return device;
        }
    }
}
