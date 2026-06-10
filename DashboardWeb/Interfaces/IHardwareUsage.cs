using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.Classes
{
    public interface IHardwareUsage
    {
        public string Title {get; set;}
        public string Color {get; set;}
        public int CurrentUsage{get; set;}
        public long GetMaxUsage();
        public void GetCurrentUsage();
    }
}