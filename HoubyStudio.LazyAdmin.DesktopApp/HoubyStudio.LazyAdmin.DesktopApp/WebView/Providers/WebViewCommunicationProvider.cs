// <copyright file="WebViewCommunicationProvider.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.WebView.Providers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;
    using Microsoft.Extensions.Logging;
    using Microsoft.Web.WebView2.Core;
    using Microsoft.Web.WebView2.Wpf;

    /// <summary>
    /// Communication with WebView provider.
    /// </summary>
    public class WebViewCommunicationProvider : IWebViewCommunicationProvider
    {
        /// <summary>
        /// Resolves to the full path of the user data folder for WebView2 component.
        /// </summary>
        /// <returns> Usually the returned folder path will conform to this format:
        /// <c>C:\Users\{username}\AppData\Local\LazyAdmin</c>.</returns>
        private static readonly string CacheFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin");

        /// <summary>
        /// Resolves to the index.html file, which gets rendered by WebView2 component.
        /// </summary>
        /// <returns> Usually the returned file path will conform to this format:
        /// <c>C:\Users\{username}\AppData\Local\LazyAdmin\EBWebView\WebResources\index.html</c>.</returns>
        private static readonly Uri IndexFilePath = new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin/EBWebView/WebResources/index.html"));

        private readonly ILogger<WebViewCommunicationProvider> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewCommunicationProvider"/> class.
        /// </summary>
        /// <param name="logger">Represents a type used to perform logging.</param>
        /// <param name="webView">WebView control assigned to this provider..</param>
        public WebViewCommunicationProvider(ILogger<WebViewCommunicationProvider> logger)
        {
            this.logger = logger;
        }

        /// <inheritdoc/>
        public virtual async Task<string> ShowMessageAsync(string message, WebView2 webView)
        {
            string result;

            try
            {
                this.logger.LogDebug("Sending an alert message to the WebView control.");
                result = await webView.CoreWebView2.ExecuteScriptAsync($"alert('{message}')");
                this.logger.LogDebug("Succesfully sent an alert message to the WebView control with result: {Result}.", result);
            }
            catch (ObjectDisposedException exception)
            {
                this.logger.LogError(exception, "Failed to send alert message to WebView2 component, because component is already disposed. Retrying initialization...");
                MainWindow.Shutdown(exception.Message);
                throw;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.LogError(exception, "Failed to send alert message to WebView2 component with unexpected error.");

                // TODO: Is this terminating error?
                // MainWindow.Shutdown(exception.Message);
                throw;
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "Failed to send alert message to the WebView2 component with unexpected error.");

                // TODO: Is this terminating error?
                // MainWindow.Shutdown(exception.Message);
                throw;
            }

            return result;
        }

        /// <inheritdoc/>
        public virtual async Task<bool> SendWebMessageAsJson(string message, WebView2 webView)
        {
            bool result = false;
            await Task.Run(() =>
            {
                // TODO: Validate if string is valid JSON? Or should we rely on C# typing?
                try
                {
                    webView.CoreWebView2.PostWebMessageAsJson(message);
                }
                catch (Exception exception)
                {
                    this.logger.LogError(exception, "Failed to post message as JSON to the WebView2 component with unexpected error.");
                }
            });
            return result;
        }

        /// <inheritdoc/>
        public virtual async Task<bool> InitializeWebView2Async(WebView2 webView)
        {
            // Register event handlers to WebView2 component
            try
            {
                webView.CoreWebView2InitializationCompleted += this.CheckWebViewInitializationStatus;
            }
            catch (Exception exception)
            {
                this.logger.LogError(exception, "Failed to register all required event handlers for WebView 2 component. Application cannot continue.");
                MainWindow.Shutdown(exception.Message);
                throw;
            }

            bool result = false;
            await Task.Run(() =>
            {
                _ = Application.Current.Dispatcher.BeginInvoke(new Action(async () =>
                {
                    CoreWebView2Environment coreWebView2Environment;

                    // Create custom WebView2 environment setting custom user data folder path
                    try
                    {
                        coreWebView2Environment = await CoreWebView2Environment.CreateAsync(null, CacheFolderPath);
                    }
                    catch (Exception exception)
                    {
                        this.logger.LogError(exception, "Failed to create WebView2 environment configuration.");
                        throw;
                    }

                    // Initialize WebView2 with custom environment settings
                    try
                    {
                        result = webView.EnsureCoreWebView2Async(coreWebView2Environment).IsCompleted;
                    }
                    catch (Exception exception)
                    {
                        this.logger.LogError(exception, "Failed to initialize WebView2 component with user data folder set to: {CacheFolderPath}.", CacheFolderPath);
                        throw;
                    }

                    // Set WebView2 component's source to Lazy Admin's UI index.html file
                    try
                    {
                        // TODO: Handle if file does not exist, try to download it or throw and quit.
                        webView.Source = new UriBuilder(IndexFilePath).Uri;
                    }
                    catch (Exception exception)
                    {
                        this.logger.LogError(exception, "Failed to load Lazy Admin's index.html file from: {IndexFilePath}.", IndexFilePath);
                        throw;
                    }
                }));
            });

            return result;
        }

        /// <summary>
        /// Checks if WebView2 component initialized without errors. More information may be found on <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2initializationcompletedeventargs">Microsoft Edge documentation</see>.
        /// <list type="table">
        /// <listheader>
        ///     <description>Possible errors</description>
        /// </listheader>
        /// <item>
        ///     <term>Failed to create user data folder</term>
        ///     <description>Process may lack permissions to create or modify user data folder for WebView2 control.</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="sender">Parameter 'sender' not used.</param>
        /// <param name="args">Paramter 'args' contains bool value with success status and potential exception object.</param>
        private void CheckWebViewInitializationStatus(object sender, CoreWebView2InitializationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                this.logger.LogInformation("Successfully initialized Lazy Admin's WebView2 comonent.");
            }
            else
            {
                this.logger.LogError(args.InitializationException, "Failed to initialize Lazy Admin's WebView2 component.");
                MainWindow.Shutdown(args.InitializationException.Message);
                throw args.InitializationException;
            }
        }
    }
}
