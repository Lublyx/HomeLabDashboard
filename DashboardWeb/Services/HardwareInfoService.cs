using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hardware.Info;

namespace DashboardWeb.Services
{
    public class HardwareInfoService
    {
        private IHardwareInfo _hardwareInfo = new HardwareInfo();

        public int GetCpuUsage()
        {
            _hardwareInfo.RefreshCPUList();
            CPU cpu =  _hardwareInfo.CpuList.First();

            IList<CpuCore> cores = cpu.CpuCoreList;

            ulong currentClock = 0;

            foreach (CpuCore core in cores)
            {
                currentClock += core.PercentProcessorTime;
            }

            return (int)(currentClock / (ulong)cores.Count);
        }

        public int GetRamUsage()
        {
            _hardwareInfo.RefreshMemoryStatus();
            return (int)((_hardwareInfo.MemoryStatus.TotalPhysical-_hardwareInfo.MemoryStatus.AvailablePhysical)/1000000000);
        }

        public ulong GetRamCapacity()
        {
            _hardwareInfo.RefreshMemoryStatus();
            return _hardwareInfo.MemoryStatus.TotalPhysical/1000000000;
        }

        public ulong GetDiskCapacity()
        {
            _hardwareInfo.RefreshDriveList();

            IList<Drive> drives = _hardwareInfo.DriveList;
            Console.WriteLine(_hardwareInfo.DriveList.Count);

            // foreach (Drive drive in drives)
            // {
                
            //     Console.WriteLine(drive.Name);
            //     // return drive.PartitionList.First(d => d.PrimaryPartition).Size;   
            //     foreach (Partition partition in drive.PartitionList)
            //     {
            //         Console.WriteLine(partition.Name);
            //     }
            // }
            return 0;
        }
    }
}