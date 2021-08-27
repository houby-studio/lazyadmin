using HoubyStudio.LazyAdmin.DesktopApp.Web.Providers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp.Web.Services
{
    /// <summary>
    /// WebView service
    /// </summary>
    public class WebViewService : IWebViewService
    {
        #region Data members

        private readonly ILogger<WebViewService> _logger;
        private readonly IWebViewCommunicationProvider _communicationProvider;

        #endregion //Data members

        #region Constructors

        public WebViewService(ILogger<WebViewService> logger, IWebViewCommunicationProvider communicationProvider)
        {
            _logger = logger;
            _communicationProvider = communicationProvider;
        }

        #endregion //Constructors

        #region Public methods

        public virtual async Task<string> ShowMessageAsync(string message)
        {
            return await _communicationProvider.ShowMessageAsync(message);
        }

        #endregion //Public methods
    }
}
