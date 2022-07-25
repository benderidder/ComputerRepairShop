using ComputerRepairShop.Domain;

namespace ComputerRepairShop.Service
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetDevices();
        Device? GetDevice(long id);
        void InsertDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}
