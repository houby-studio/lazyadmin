// <copyright file="IPwshProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Providers
{
    using Microsoft.Web.WebView2.Core;
    using System.Threading.Tasks;

    /// <summary>
    /// PowerShell process provider interface.
    /// </summary>
    public interface IPwshProvider
    {
        /// <summary>
        /// Handles message received from <see cref="WebView.Providers.WebViewCommunicationProvider"/>.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="args">Arguments received from the event.</param>
        public void ReceiveMessageFromWebView(object sender, CoreWebView2WebMessageReceivedEventArgs args);
    }
}
