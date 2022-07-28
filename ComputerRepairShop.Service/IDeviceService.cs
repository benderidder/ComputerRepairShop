using ComputerRepairShop.Domain;

namespace ComputerRepairShop.Service
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetAllDevices();
        Device GetDevice(long id);
        void SaveDevice(Device device);
        void DeleteDevice(Device device);
    }
}
