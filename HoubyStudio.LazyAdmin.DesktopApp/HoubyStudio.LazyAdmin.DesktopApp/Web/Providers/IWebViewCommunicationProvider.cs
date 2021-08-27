using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp.Web.Providers
{
    /// <summary>
    /// Communication with WebView provider interface
    /// </summary>
    public interface IWebViewCommunicationProvider
    {
        Task<string> ShowMessageAsync(string message);
    }
}
