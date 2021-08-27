using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       services.AddScoped<Web.Providers.IWebViewCommunicationProvider, Web.Providers.WebViewCommunicationProvider>();
                       services.AddScoped<Web.Services.IWebViewService, Web.Services.WebViewService>();
                       services.AddScoped<Pwsh.Services.IPwshService, Pwsh.Services.PwshService>();
                       services.AddSingleton<MainWindow>();
                   })
                   .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}
