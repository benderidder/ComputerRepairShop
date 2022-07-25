using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;

namespace ComputerRepairShop.Service
{
    public class DeviceService : IDeviceService
    {
        private IRepository<Device> deviceRepository;

        public DeviceService(IRepository<Device> deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public IEnumerable<Device> GetDevices()
        {
            return deviceRepository.GetAll();
        }

        public Device? GetDevice(long id)
        {
            return deviceRepository.Get(id);
        }

        public void InsertDevice(Device device)
        {
            deviceRepository.Insert(device);
        }

        public void UpdateDevice(Device device)
        {
            deviceRepository.Update(device);
        }

        public void DeleteDevice(Device device)
        {
            deviceRepository.Delete(device);
        }
    }
}