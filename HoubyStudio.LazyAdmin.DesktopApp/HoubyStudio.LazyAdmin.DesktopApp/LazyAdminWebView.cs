﻿// <copyright file="LazyAdminWebView.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.IO;
    using Microsoft.Web.WebView2.Core;
    using Microsoft.Web.WebView2.Wpf;
    using Newtonsoft.Json;

    /// <summary>
    /// <para> Class <c>LazyAdminWebView</c> handles initialization and script injection to WebView2 control.<br />
    /// Additionally handles communication from host to WebView2 control via method <c>PostWebMessageAsJSON</c>.<br />
    /// </para>
    /// <example>For example:
    /// <code>
    ///     LazyAdminWebView.PostWebMessageAsJSON(powershell.output);
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="WebView">the WebView2 control created from XAML markup file.</param>
    /// <see cref="CoreWebView2.PostWebMessageAsJSON"/>
    /// <see cref="PostWebMessageAsJSON"/>
    public static class LazyAdminWebView
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

        private static WebView2 _webView;

        public static WebView2 WebView
        {
            set => _webView = value;
        }

        /// <summary>
        /// Displays alert message within the WebView2 control.
        /// </summary>
        /// <param name="message">String displayed in the alert popup.</param>
        public static void ShowMessage(string message)
        {
            _webView.CoreWebView2.ExecuteScriptAsync($"alert('{message}')");
        }

        /// <summary>
        /// Change Runspace status.
        /// </summary>
        public static void PostRunspaceStatus(Guid uid, string status, string result)
        {
            CSharpRunspaceStatusMessage jsonMessage = new(uid, status, result);

            string jsonString = JsonConvert.SerializeObject(jsonMessage);
            _webView.CoreWebView2.PostWebMessageAsJson(jsonString);
        }

        /// <summary>
        /// Change Runspace status.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="status">status.</param>
        public static void PostRunspaceStatus(Guid uid, string status)
        {
            CSharpRunspaceStatusMessage jsonMessage = new(uid, status);

            string jsonString = JsonConvert.SerializeObject(jsonMessage);
            _webView.CoreWebView2.PostWebMessageAsJson(jsonString);
        }

        /// <summary>
        /// Posts WebMessage in the JSON form to the WebView2 control.
        /// </summary>
        /// <param name="message">JSON sent to the WebView2 control.</param>
        public static void PostWebMessageAsJSON(string message)
        {
            PowerShellData jsonMessage = new(message);

            string jsonString = JsonConvert.SerializeObject(jsonMessage);
            _webView.CoreWebView2.PostWebMessageAsJson(jsonString);
        }

        /// <summary>
        /// Initializes new WebView2 instance with custom environment settings.<br />
        /// Then ensures latest Lazy Admin UI files are present and loads them within the WebView2 control.
        /// </summary>
        public static async void InitializeWebView()
        {
            // Initialize WebView with custom environment settings
            CoreWebView2Environment coreWebView2Environment = await CoreWebView2Environment.CreateAsync(null, CacheFolderPath);
            await _webView.EnsureCoreWebView2Async(coreWebView2Environment);

            // TODO: Check if Lazy Admin's index.html exists, is loaded and can be injected.
            _webView.Source = new UriBuilder(IndexFilePath).Uri;

            // Register event listener inside website
            // TODO: replace with listener, which triggers function to handle PowerShell result
            // await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");

            // Register event listener for PowerShell handler
            //_webView.CoreWebView2.WebMessageReceived += MainWindow.GetLazyAdminPwsh().ReceiveMessage;
        }
    }
}
