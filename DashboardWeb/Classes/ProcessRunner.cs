using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardWeb.Classes
{
    public static class ProcessRunner
    {
        
        public static void Run(string filename, string argmuments)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = argmuments,
                CreateNoWindow = true,
                UseShellExecute = false,
                UserName = "lucas"
            };
            Process.Start(processStartInfo);
        }

        public static string Run(string filename, string argmuments, bool enableOutput)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = argmuments,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = enableOutput
            };
            
            Process process = Process.Start(processStartInfo)!;

            StreamReader reader = process.StandardOutput;
            return reader.ReadToEnd();
        }
    }
}