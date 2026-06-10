using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hardware.Info;

namespace DashboardWeb.Classes
{
    public class CpuUsage : IHardwareUsage
    {
        public required string Title {get; set;}
        public required string Color {get; set;}
        public int CurrentUsage{get; set;}
        private IHardwareInfo _hardwareInfo = new HardwareInfo();

        
        public long GetMaxUsage() => 100;

        public void GetCurrentUsage()
        {
            _hardwareInfo.RefreshCPUList();
            CPU cpu = _hardwareInfo.CpuList.First();

            IList<CpuCore> cores = cpu.CpuCoreList;

            ulong currentClock = 0;

            foreach (CpuCore core in cores)
            {
                currentClock += core.PercentProcessorTime;
            }

            CurrentUsage = (int)(currentClock / (ulong)cores.Count);
        }
    }
}