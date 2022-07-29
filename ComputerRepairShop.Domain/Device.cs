using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepairShop.Domain
{
    public class Device : EntityBase
    {
        public string SerialNumber { get; set; } = string.Empty;
    }
}
