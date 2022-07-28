using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;

namespace ComputerRepairShop.Service
{
    public class DeviceService : IDeviceService
    {
        private readonly IRepository<Device> _deviceRepository;

        public DeviceService(IRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _deviceRepository.GetAll();
        }

        public Device GetDevice(long id)
        {
            var device = _deviceRepository.Get(id);

            if(device != null)
            {
                return device;
            }
            else
            {
                throw new ArgumentException($"No device found for id {id}");
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