// <copyright file="IWebViewCommunicationProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// Communication with WebView provider interface.
    /// </summary>
    public interface IWebViewCommunicationProvider
    {
        /// <summary>
        /// Displays string as an alert in the WebView control.
        /// </summary>
        /// <param name="message">Message to be displayed in the WebView control.</param>
        /// <param name="webView">Target WebView control.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> ShowMessageAsync(string message, WebView2 webView);

        /// <summary>
        /// Initializes WebView2 control.
        /// </summary>
        /// <param name="webView">WebView2 control.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<bool> EnsureCoreWebView2Async(WebView2 webView);
    }
}
