// <copyright file="IWebViewCommunicationProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers
{
    using System.Threading.Tasks;
    using HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Services;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// Communication with WebView provider interface.
    /// </summary>
    public interface IWebViewCommunicationProvider
    {
        /// <summary>
        /// Displays string as an alert in the WebView2 control.
        /// </summary>
        /// <param name="message">Message to be displayed in the WebView control.</param>
        /// <param name="webView">Target WebView2 control.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<string> ShowMessageAsync(string message, WebView2 webView);

        /// <summary>
        /// Sends message formatted as JSON to the WebView2 control.
        /// </summary>
        /// <param name="message">Serialized JSON object to be sent to the WebView2 control.</param>
        /// <param name="webView">Target WebView2 control.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation.</returns>
        public Task<bool> SendWebMessageAsJson(string message, WebView2 webView);

        /// <summary>
        /// Initializes WebView2 control.
        /// </summary>
        /// <param name="webView">WebView2 control.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation.</returns>
        public Task<bool> InitializeWebView2Async(WebView2 webView, IPwshService pwshService);
    }
}
