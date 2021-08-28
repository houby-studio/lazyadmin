// <copyright file="IWebViewService.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Web.Services
{
    using System.Threading.Tasks;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// WebView service interface.
    /// </summary>
    public interface IWebViewService
    {
        /// <inheritdoc cref="HoubyStudio.LazyAdmin.DesktopApp.Web.Providers.IWebViewCommunicationProvider.ShowMessageAsync(string)"/>
        Task<string> ShowMessageAsync(string message);

        /// <inheritdoc/>
        public void SetWebView(WebView2 webView);
    }
}
