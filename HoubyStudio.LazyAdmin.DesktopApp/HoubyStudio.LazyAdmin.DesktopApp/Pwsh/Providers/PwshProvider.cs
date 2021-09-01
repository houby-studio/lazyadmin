// <copyright file="PwshProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Providers
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Web.WebView2.Core;

    /// <summary>
    /// PowerShell process provider.
    /// </summary>
    public class PwshProvider : IPwshProvider
    {
        private ILogger<PwshProvider> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PwshProvider"/> class.
        /// </summary>
        /// <param name="logger">Dependent logger interface.</param>
        public PwshProvider(ILogger<PwshProvider> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public virtual void ReceiveMessageFromWebView(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            this.logger.LogInformation("Received message from Webview!");
            return;
        }
    }
}
