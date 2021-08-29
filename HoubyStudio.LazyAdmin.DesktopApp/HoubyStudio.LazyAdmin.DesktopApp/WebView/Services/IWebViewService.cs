// <copyright file="IWebViewService.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Services
{
    using System.Threading.Tasks;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// WebView service interface.
    /// </summary>
    public interface IWebViewService
    {
        /// <inheritdoc cref="HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers.IWebViewCommunicationProvider.ShowMessageAsync(string)"/>
        public Task<string> ShowMessageAsync(string message, WebView2 webView);

        /// <inheritdoc cref="HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers.IWebViewCommunicationProvider.EnsureCoreWebView2Async(WebView2)"/>
        public Task<bool> EnsureCoreWebView2Async(WebView2 webView);
    }
}
