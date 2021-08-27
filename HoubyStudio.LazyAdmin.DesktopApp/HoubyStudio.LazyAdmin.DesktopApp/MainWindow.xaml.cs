using HoubyStudio.LazyAdmin.DesktopApp.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.IO;
using System.Windows;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Service provider
        /// </summary>
        //protected readonly IServiceProvider _services;

        protected readonly IWebViewService _webViewService;

        private static WebView2 _webView;

        private static LazyAdminPowerShell _lazyAdminPwsh = new();

        public static WebView2 WebView
        {
            get => _webView;
            set => _webView = value;
        }

        public static LazyAdminPowerShell LazyAdminPwsh
        {
            get => _lazyAdminPwsh;
            set => _lazyAdminPwsh = value;
        }

        public MainWindow(IWebViewService webViewService)
        {
            // Required. Loads the compiled page of a component from XAML.
            InitializeComponent();

            // Map webView generated from XAML to LazyAdminWebView, which initializes component.
            LazyAdminWebView.WebView = webView;
            _webView = webView;

            _webViewService = webViewService;

            LazyAdminPwsh.MockPowerShell = PowerShell;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            try
            {
                // Let WebView to initialize itself
                LazyAdminWebView.InitializeWebView();
            }
            catch (Exception)
            {
                // TODO: String to resource for translation
                Shutdown("An error occurred when starting the browser. Browser window will close.", "Error Occurred");
            }
        }

        // TODO: String to resource for translation
        private void Shutdown(string message, string caption = "Information")
        {
            _ = MessageBox.Show(this, message, caption);
            Application.Current.Shutdown();
        }

        private async void Execute_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Are we able to load service using scope and service provider?
            //using var scope = _services.CreateScope();
            //var webViewService = scope.ServiceProvider.GetRequiredService<IWebViewService>();
            var result = await _webViewService.ShowMessageAsync("PowerShell.Text");
        }

        public static void ShowMessageFromThread(Guid uid, string status, string message)
        {
            LazyAdminWebView.PostRunspaceStatus(uid, status, message);
        }

        public static void ShowMessageFromThread(Guid uid, string status)
        {
            LazyAdminWebView.PostRunspaceStatus(uid, status);
        }
    }
}
