using ComputerRepairShop.Domain;
using ComputerRepairShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace ComputerRepairShop.WebAPI.Controllers
{
    [ApiController]
    [Route("devices")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDeviceService _deviceService;

        public DeviceController(ILogger<DeviceController> logger, IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;
        }

        [HttpGet(Name = "GetDevices")]
        public IEnumerable<Device> Get()
        {
            return _deviceService.GetAllDevices();
        }

        [HttpGet("{id}", Name = "GetDeviceById")]
        public Device GetById(long id)
        {
            return _deviceService.GetDevice(id);
        }

        [HttpPost(Name = "PostDevice")]
        public void Post(Device device)
        {
            _deviceService.SaveDevice(device);
        }

        [HttpDelete(Name = "DeleteDevice")]
        public void Delete(long id)
        {
            _deviceService.DeleteDevice(GetById(id));
        }
    }
}
