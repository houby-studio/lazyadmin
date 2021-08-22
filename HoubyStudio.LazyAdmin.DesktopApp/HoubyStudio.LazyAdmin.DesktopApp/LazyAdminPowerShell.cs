using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    /// <summary>
    /// Handles postMessage events received from EdgeView2 control.
    /// </summary>
    public static class LazyAdminPowerShell
    {

        // Mock PowerShell
        private static TextBox _powerShell;

        public static TextBox PowerShell
        {
            set => _powerShell = value;
        }

        public static void ReceiveMessage(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            try
            {
                // TODO: Replace with args.WebMessageAsJson and handle data accordingly
                _powerShell.Text = args.TryGetWebMessageAsString();
            } catch
            {
                _powerShell.Text = "";
            }
        }
    }
}
