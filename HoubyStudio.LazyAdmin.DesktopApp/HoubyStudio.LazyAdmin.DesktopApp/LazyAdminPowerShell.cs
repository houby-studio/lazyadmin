using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    /// <summary>
    /// Handles postMessage events received from EdgeView2 control.
    /// </summary>
    class LazyAdminPowerShell
    {
        public string Message { get; set; }

        public void ShowMessage()
        {
            _ = System.Windows.MessageBox.Show(Message);
        }
    }
}
