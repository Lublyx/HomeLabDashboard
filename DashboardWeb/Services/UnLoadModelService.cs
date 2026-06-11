using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DashboardWeb.Classes;

namespace DashboardWeb.Services
{
    public class UnLoadModelService
    {
        
        public void UnLoad(string modelPath)
        {
            string result = ProcessRunner.Run("/bin/bash", $"-c \"/bin/ps aux | /bin/grep \"{modelPath}\"\"", true);
            Console.WriteLine(result);

            Regex regex = new Regex(@"lucas\s{0,}(\d{0,})  ");
        }
    }
}