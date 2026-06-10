using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.Classes
{
    public class DiskUsage : IHardwareUsage
    {
        public required string Title {get; set;}
        public required string Color {get; set;}
        public int CurrentUsage{get; set;}
        DriveInfo _drive = new DriveInfo(Directory.GetDirectoryRoot(AppDomain.CurrentDomain.BaseDirectory));


        public long GetMaxUsage()
        {
            return _drive.TotalSize / (1024 * 1024 * 1024);
        }

        public void GetCurrentUsage()
        {
            CurrentUsage = (int)((_drive.TotalSize - _drive.TotalFreeSpace) / (1024 * 1024 * 1024));
        }
    }
}