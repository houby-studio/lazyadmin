﻿// <copyright file="MainWindow.xaml.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.IO;
    using System.Windows;
    using HoubyStudio.LazyAdmin.DesktopApp.Pwsh.Services;
    using HoubyStudio.LazyAdmin.DesktopApp.WebView.Services;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Web.WebView2.Core;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Service provider.
        /// </summary>
        // protected readonly IServiceProvider _services;
        // private static WebView2 webView1;
        // public static WebView2 WebView => webView1;
        // public static void SetWebView(WebView2 value) => webView1 = value;
        private readonly IWebViewService webViewService;
        private readonly IPwshService pwshService;

        //private static LazyAdminPowerShell lazyAdminPwsh = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="webViewService">WebView service.</param>
        /// <param name="pwshService">Pwsh service.</param>
        public MainWindow(IWebViewService webViewService, IPwshService pwshService)
        {
            // Required. Loads the compiled page of a component from XAML.
            this.InitializeComponent();

            // Map vw generated from XAML to LazyAdminWebView, which initializes component.
            // LazyAdminWebView.WebView = this.webView;
            // SetWebView(this.webView);
            this.webViewService = webViewService;
            this.pwshService = pwshService;
            this.webViewService.InitializeWebView2Async(this.webView, this.pwshService);
            // TODO: https://codewithshadman.com/mediator-pattern-csharp/
            this.webView.CoreWebView2.WebMessageReceived += this.pwshService.ReceiveMessageFromWebView;


            //GetLazyAdminPwsh().MockPowerShell = this.PowerShell;
        }

        ///// <summary>
        ///// Gets LazyAdminPowerShell object.
        ///// </summary>
        ///// <returns>LazyAdminPowerShell.</returns>
        //public static LazyAdminPowerShell GetLazyAdminPwsh()
        //{
        //    return lazyAdminPwsh;
        //}

        ///// <summary>
        ///// Sets LazyAdminPowerShell object.
        ///// </summary>
        //public static void SetLazyAdminPwsh(LazyAdminPowerShell value)
        //{
        //    lazyAdminPwsh = value;
        //}

        ///// <summary>
        ///// Displays Message.
        ///// </summary>
        ///// <param name="uid">Uid.</param>
        ///// <param name="status">Status.</param>
        ///// <param name="message">Message.</param>
        //public static void ShowMessageFromThread(Guid uid, string status, string message)
        //{
        //    LazyAdminWebView.PostRunspaceStatus(uid, status, message);
        //}

        ///// <summary>
        ///// Displays Message.
        ///// </summary>
        ///// <param name="uid">Uid.</param>
        ///// <param name="status">Status.</param>
        //public static void ShowMessageFromThread(Guid uid, string status)
        //{
        //    LazyAdminWebView.PostRunspaceStatus(uid, status);
        //}

        //protected override void OnContentRendered(EventArgs e)
        //{
        //    base.OnContentRendered(e);

        //    try
        //    {
        //        // Let WebView to initialize itself
        //        LazyAdminWebView.InitializeWebView();
        //    }
        //    catch (Exception)
        //    {
        //        // TODO: String to resource for translation
        //        this.Shutdown("An error occurred when starting the browser. Browser window will close.", "Error Occurred");
        //    }
        //}

        /// <summary>
        /// Show terminating error message and shuts down application.
        /// </summary>
        /// <param name="message">Error message to be displayed in the message box.</param>
        public static void Shutdown(string message)
        {
            _ = MessageBox.Show(
                        messageBoxText: $"Lazy Admin crashed. Oops. Sorry for inconvenience.{Environment.NewLine}Error message:{Environment.NewLine}{message}",
                        caption: "Lazy Admin encountered critical error!",
                        button: MessageBoxButton.OK,
                        icon: MessageBoxImage.Error);
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Method executed on button click.
        /// </summary>
        /// <param name="sender">Parameter 'sender' not used.</param>
        /// <param name="e">Parameter 'e' not used.</param>
        private async void Execute_Click(object sender, RoutedEventArgs e)
        {
            _ = await this.webViewService.ShowMessageAsync(this.PowerShell.Text, this.webView);
        }
    }
}
