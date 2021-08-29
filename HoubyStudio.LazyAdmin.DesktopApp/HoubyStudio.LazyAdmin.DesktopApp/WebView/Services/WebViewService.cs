﻿// <copyright file="WebViewService.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers;
    using Microsoft.Extensions.Logging;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// WebView service.
    /// </summary>
    public class WebViewService : IWebViewService
    {
        private readonly ILogger<WebViewService> logger;
        private readonly IWebViewCommunicationProvider communicationProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewService"/> class.
        /// </summary>
        /// <param name="logger">TODO:1.</param>
        /// <param name="communicationProvider">TODO:2.</param>
        public WebViewService(ILogger<WebViewService> logger, IWebViewCommunicationProvider communicationProvider)
        {
            this.logger = logger;
            this.communicationProvider = communicationProvider;

            this.logger.LogInformation("Created new WebViewService");
        }

        /// <inheritdoc/>
        public virtual async Task<string> ShowMessageAsync(string message, WebView2 webView)
        {
            return await this.communicationProvider.ShowMessageAsync(message, webView);
        }

        /// <inheritdoc/>
        public virtual async Task<bool> EnsureCoreWebView2Async(WebView2 webView)
        {
            return await this.communicationProvider.EnsureCoreWebView2Async(webView);
        }
    }
}