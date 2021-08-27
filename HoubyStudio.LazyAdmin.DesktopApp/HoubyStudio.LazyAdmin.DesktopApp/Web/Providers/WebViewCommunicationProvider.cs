using Microsoft.Extensions.Logging;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp.Web.Providers
{
    /// <summary>
    /// Communication with WebView provider
    /// </summary>
    public class WebViewCommunicationProvider : IWebViewCommunicationProvider
    {
        private static readonly WebView2 _webView = MainWindow.WebView;
        private readonly ILogger<WebViewCommunicationProvider> _logger;

        public WebViewCommunicationProvider(ILogger<WebViewCommunicationProvider> logger)
        {
            _logger = logger;
        }

        public virtual async Task<string> ShowMessageAsync(string message)
        {
            string result = null;

            try
            {
                _logger.LogDebug("Sending an alert message to the WebView control.");
                result = await _webView.CoreWebView2.ExecuteScriptAsync($"alert('{message}')");
            }
            catch
            {
                _logger.LogDebug("Succesfully executed script in the WebView control.");
            }

            return result;
        }
    }
}
