namespace ComputerRepairShop.Domain
{
    public class DeviceServiceOrder : EntityBase
    {
        public Device Device { get; set; } = new Device();

        public ServiceOrder ServiceOrder { get; set; } = new ServiceOrder();

        public string Description { get; set; } = string.Empty;
    }
}
