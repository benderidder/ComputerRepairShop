using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using Microsoft.Extensions.Logging;

namespace ComputerRepairShop.Service
{
    public class DeviceService : ServiceBase<Device>, IDeviceService
    {
        public DeviceService(ILogger<DeviceService> logger, IRepository<Device> deviceRepository) : base(logger, deviceRepository)
        {
        }

        public IEnumerable<Device> GetAllDevices()
        {
            base._logger.LogInformation("Get all devices");
            return base.GetAll();
        }

        public Device GetDevice(long id)
        {
            base._logger.LogInformation("Get device");
            return base.Get(id);
        }

        public void SaveDevice(Device device)
        {
            base._logger.LogInformation("Save device");
            base.Save(device);
        }

        public void DeleteDevice(Device device)
        {
            base._logger.LogInformation("Delete device");
            base.Delete(device);
        }
    }
}