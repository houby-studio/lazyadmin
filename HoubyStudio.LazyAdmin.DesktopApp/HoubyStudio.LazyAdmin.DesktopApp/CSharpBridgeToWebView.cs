using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    class CSharpBridgeToWebView
    {
        public string Message;
        public Microsoft.Web.WebView2.Wpf.WebView2 WebView;

        public void ShowMessage()
        {
            WebView.CoreWebView2.ExecuteScriptAsync($"alert('{Message}')");
        }
    }
}
