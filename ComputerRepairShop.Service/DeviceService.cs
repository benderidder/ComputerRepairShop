using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;

namespace ComputerRepairShop.Service
{
    public class DeviceService : IDeviceService
    {
        private IRepository<Device> _deviceRepository;

        public DeviceService(IRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IEnumerable<Device> GetDevices()
        {
            return _deviceRepository.GetAll();
        }

        public Device? GetDevice(long id)
        {
            return _deviceRepository.Get(id);
        }

        public void InsertDevice(Device device)
        {
            _deviceRepository.Insert(device);
        }

        public void UpdateDevice(Device device)
        {
            _deviceRepository.Update(device);
        }

        public void DeleteDevice(Device device)
        {
            _deviceRepository.Delete(device);
        }
    }
}