// <copyright file="IWebViewCommunicationProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Web.Providers
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
        /// <param name="message">Message to be displayed WebView control.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<string> ShowMessageAsync(string message);

        /// <summary>
        /// Sets WebView control for current provider.
        /// </summary>
        /// <param name="webView">WebView2 control.</param>
        /// /// <returns><Void>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task EnsureCoreWebView2Async(WebView2 webView);
    }
}
