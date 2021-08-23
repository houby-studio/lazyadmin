using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    /// <summary>
    /// Handles postMessage events received from EdgeView2 control.
    /// </summary>
    public class LazyAdminPowerShell
    {


        private PowerShell _powerShell;
        private RunspacePool runespacePool = RunspaceFactory.CreateRunspacePool();

        //public static TextBox PowerShell
        //{
        //    set => _powerShell = value;
        //}

        public void ReceiveMessage(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            try
            {
                // TODO: Replace with args.WebMessageAsJson and handle data accordingly
                //_powerShell = args.TryGetWebMessageAsString();
            }
            catch
            {
                //_powerShell = "";
            }
        }
    }
}
