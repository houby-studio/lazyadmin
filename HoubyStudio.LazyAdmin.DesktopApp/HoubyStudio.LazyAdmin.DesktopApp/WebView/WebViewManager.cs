using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView
{
    public class WebViewManager
    {
        public WebView2 WebView;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewManager"/> class.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        /// <param name="services">Defines a mechanism for retrieving a service object; that is, an object that provides custom support to other objects.</param>
        /// <param name="logger">Represents a type used to perform logging.</param>
        public WebViewManager(IConfiguration configuration, IServiceProvider services, ILogger<WebViewManager> logger)
        {

        }
    }
}
