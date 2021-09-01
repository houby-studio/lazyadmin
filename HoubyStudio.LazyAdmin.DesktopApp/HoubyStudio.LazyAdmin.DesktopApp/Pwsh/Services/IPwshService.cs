// <copyright file="IPwshService.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Services
{
    using System.Threading.Tasks;
    using Microsoft.Web.WebView2.Core;

    /// <summary>
    /// PowerShell service interface.
    /// </summary>
    public interface IPwshService
    {
        /// <inheritdoc cref="Providers.IPwshProvider.ReceiveMessageFromWebView(object,CoreWebView2WebMessageReceivedEventArgs)"/>
        public void ReceiveMessageFromWebView(object sender, CoreWebView2WebMessageReceivedEventArgs args);

        public void Halo();
    }
}
