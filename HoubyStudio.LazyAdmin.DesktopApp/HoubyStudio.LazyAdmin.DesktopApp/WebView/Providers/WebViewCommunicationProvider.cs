// <copyright file="WebViewCommunicationProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// Communication with WebView provider.
    /// </summary>
    public class WebViewCommunicationProvider : IWebViewCommunicationProvider
    {
        private readonly ILogger<WebViewCommunicationProvider> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewCommunicationProvider"/> class.
        /// </summary>
        /// <param name="logger">Represents a type used to perform logging.</param>
        /// <param name="webView">WebView control assigned to this provider..</param>
        public WebViewCommunicationProvider(ILogger<WebViewCommunicationProvider> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public virtual async Task<string> ShowMessageAsync(string message, WebView2 webView)
        {
            string result = null;

            try
            {
                this.logger.LogDebug("Sending an alert message to the WebView control.");
                result = await webView.CoreWebView2.ExecuteScriptAsync($"alert('{message}')");
            }
            catch
            {
                this.logger.LogDebug("Succesfully executed script in the WebView control.");
            }

            return result;
        }

        /// <inheritdoc/>
        public virtual async Task<bool> EnsureCoreWebView2Async(WebView2 webView)
        {
            bool result = false;
            await Task.Run(() =>
            {
                // TODO: Ensure WebView is present with all the settings.
                _ = System.Windows.Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    result = webView.EnsureCoreWebView2Async().IsCompleted;
                }));
            });

            return result;
        }
    }
}
