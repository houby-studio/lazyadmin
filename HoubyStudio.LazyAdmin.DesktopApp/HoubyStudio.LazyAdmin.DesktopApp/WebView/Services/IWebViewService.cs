﻿// <copyright file="IWebViewService.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Services
{
    using System.Threading.Tasks;
    using HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Services;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// WebView service interface.
    /// </summary>
    public interface IWebViewService
    {
        /// <inheritdoc cref="Providers.IWebViewCommunicationProvider.ShowMessageAsync(string)"/>
        public Task<string> ShowMessageAsync(string message, WebView2 webView);

        /// <inheritdoc cref="Providers.IWebViewCommunicationProvider.SendWebMessageAsJson(string, WebView2)"/>
        public Task<bool> SendWebMessageAsJson(string message, WebView2 webView);

        /// <inheritdoc cref="Providers.IWebViewCommunicationProvider.EnsureCoreWebView2Async(WebView2, IPwshService)"/>
        public Task<bool> InitializeWebView2Async(WebView2 webView, IPwshService pwshService);
    }
}
