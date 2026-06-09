using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hardware.Info;

namespace DashboardWeb.Services
{
    public class HardwareInfoService
    {
        IHardwareInfo hardwareInfo = new HardwareInfo();

        public int GetCpuUsage()
        {
            hardwareInfo.RefreshCPUList();
            CPU cpu =  hardwareInfo.CpuList.First();

            IList<CpuCore> cores = cpu.CpuCoreList;

            ulong currentClock = 0;

            foreach (CpuCore core in cores)
            {
                currentClock += core.PercentProcessorTime;
            }

            return (int)(currentClock / (ulong)cores.Count);
        }
    }
}