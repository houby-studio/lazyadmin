// <copyright file="PwshService.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Services
{
    using HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Providers;
    using Microsoft.Extensions.Logging;
    using Microsoft.Web.WebView2.Core;
    using System.Threading.Tasks;

    /// <summary>
    /// PowerShell service creates and manages PowerShell runspaces and processes, exposes method, which allows WebViewService to register events to it.
    /// </summary>
    public class PwshService : IPwshService
    {
        private readonly ILogger<PwshService> logger;
        private readonly IPwshProvider pwshProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="PwshService"/> class.
        /// </summary>
        /// <param name="logger">Dependent logger interface.</param>
        /// <param name="pwshProvider">Dependent pwsh provider interface. </param>
        public PwshService(ILogger<PwshService> logger, IPwshProvider pwshProvider)
        {
            this.logger = logger;
            this.pwshProvider = pwshProvider;

            this.logger.LogDebug("Created new PwshService");
        }

        /// <inheritdoc/>
        public void ReceiveMessageFromWebView(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            this.pwshProvider.ReceiveMessageFromWebView(sender, args);
            return;
        }

        public void Halo()
        {
            this.logger.LogInformation("WTFFFFFFFFFFFF?!?!");
        }
    }
}
