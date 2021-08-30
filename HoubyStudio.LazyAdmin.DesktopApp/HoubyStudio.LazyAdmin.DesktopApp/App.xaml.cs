// <copyright file="App.xaml.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Application's entry point.
        /// </summary>
        public App()
        {
            // Create generic host to inject services
            this.host = Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       _ = services.AddScoped<WebView.Providers.IWebViewCommunicationProvider, WebView.Providers.WebViewCommunicationProvider>();
                       _ = services.AddScoped<WebView.Services.IWebViewService, WebView.Services.WebViewService>();
                       _ = services.AddScoped<Pwsh.Services.IPwshService, Pwsh.Services.PwshService>();
                       _ = services.AddSingleton<MainWindow>();
                   })
                   .Build();
        }

        /// <summary>
        /// Application startup method.
        /// </summary>
        /// <param name="sender">Parameter not used.</param>
        /// <param name="e">Contains the arguments for the Startup event.</param>
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await this.host.StartAsync();

            MainWindow mainWindow = this.host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        /// <summary>
        /// Application exit method.
        /// </summary>
        /// <param name="sender">Parameter not used.</param>
        /// <param name="e">Gets or sets the exit code that an application returns to the operating system when the application exits.</param>
        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (this.host)
            {
                CancellationTokenSource timeoutCts = new CancellationTokenSource(1000);

                await this.host.RunAsync(timeoutCts.Token);
            }

            this.OnExit(e);
        }
    }
}
