using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Hardware.Info;

namespace DashboardWeb.Classes
{
    public class BatteryStatus : IHardwareUsage
    {
        public required string Title {get; set;}
        public required string Color {get; set;}
        public int CurrentUsage{get; set;}
        private IHardwareInfo _hardwareInfo = new HardwareInfo();

        public long GetMaxUsage() => 100;
    

        public void GetCurrentUsage()
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "/bin/cat";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput =true;
                process.StartInfo.Arguments = "/sys/class/power_supply/BAT1/capacity";
                process.Start();

                StreamReader reader = process.StandardOutput;
                CurrentUsage = Convert.ToInt32(reader.ReadLine());
            }
        }
    }
}