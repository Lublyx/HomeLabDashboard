using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hardware.Info;

namespace DashboardWeb.Classes
{
    public class RamUsage : IHardwareUsage
    {
        public required string Title {get; set;}
        public required string Color {get; set;}
        public int CurrentUsage{get; set;}
        private IHardwareInfo _hardwareInfo = new HardwareInfo();

        public long GetMaxUsage()
        {
            _hardwareInfo.RefreshMemoryStatus();
            return (long)(_hardwareInfo.MemoryStatus.TotalPhysical / (1000 * 1000 * 1000));
        }

        public void GetCurrentUsage()
        {
            _hardwareInfo.RefreshMemoryStatus();
            CurrentUsage = (int)((_hardwareInfo.MemoryStatus.TotalPhysical - _hardwareInfo.MemoryStatus.AvailablePhysical) / (1000 * 1000 * 1000));
        }
    }
}