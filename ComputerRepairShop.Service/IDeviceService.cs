using ComputerRepairShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
