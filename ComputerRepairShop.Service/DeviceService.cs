using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using Microsoft.Extensions.Logging;

namespace ComputerRepairShop.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly ILogger<DeviceService> _logger;
        private readonly IRepository<Device> _deviceRepository;

        public DeviceService(ILogger<DeviceService> logger, IRepository<Device> deviceRepository)
        {
            _logger = logger;
            _deviceRepository = deviceRepository;
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _deviceRepository.GetAll();
        }

        public Device GetDevice(long id)
        {
            try
            {
                var device = _deviceRepository.Get(id);

                if (device != null)
                {
                    return device;
                }
                else
                {
                    throw new ArgumentException($"No device found for id {id}");
                }
            } 
            catch(Exception ex)
            {
                _logger.LogError("GetDevice failed: {message}", ex.Message);
                throw;
            }
        }

        public void SaveDevice(Device device)
        {
            if (device == null) throw new ArgumentException($"No device was provided to save");

            if (device.Id == 0)
            {
                _deviceRepository.Insert(device);
            }
            else
            {
                _deviceRepository.Update(device);
            }
        }

        public void DeleteDevice(Device device)
        {
            if (device == null) throw new ArgumentException($"No device was provided to delete");

            _deviceRepository.Delete(device);
        }
    }
}