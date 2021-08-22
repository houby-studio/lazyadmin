using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    public class PowerShellData
    {
        public DateTime Date { get; set; }
        public string Data { get; set; }

        public PowerShellData(string data)
        {
            Date = DateTime.Now;
            Data = data;
        }
    }
}
