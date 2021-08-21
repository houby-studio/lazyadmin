using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.IO;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
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

        private static WebView2 _webView;

        public static WebView2 WebView
        {
            set => _webView = value;
        }

        /// <summary>
        /// Resolves to the full path of the user data folder for WebView2 component.
        /// </summary>
        /// <returns> Usually the returned folder path will conform to this format:
        /// <c>C:\Users\{username}\AppData\Local\LazyAdmin</c></returns>
        private static readonly string _cacheFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin");

        /// <summary>
        /// Resolves to the index.html file, which gets rendered by WebView2 component.
        /// </summary>
        /// <returns> Usually the returned file path will conform to this format:
        /// <c>C:\Users\{username}\AppData\Local\LazyAdmin\EBWebView\WebResources\index.html</c></returns>
        private static readonly Uri _indexFilePath = new Uri(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin/EBWebView/WebResources/index.html"));

        public static void ShowMessage(string Message)
        {
            _webView.CoreWebView2.ExecuteScriptAsync($"alert('{Message}')");
        }

        public static void PostWebMessageAsJSON(string Message)
        {
            _webView.CoreWebView2.PostWebMessageAsJson($"{{json: true, msg: {Message}}}");
        }

        public static async void InitializeWebView()
        {
            // Initialize WebView with custom environment settings
            CoreWebView2Environment coreWebView2Environment = await CoreWebView2Environment.CreateAsync(null, _cacheFolderPath);
            await _webView.EnsureCoreWebView2Async(coreWebView2Environment);

            // TODO: Check if Lazy Admin's index.html exists, is loaded and can be injected.
            _webView.Source = new UriBuilder(_indexFilePath).Uri;

            //await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            // Register event listener inside website
            _ = await _webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        }
    }
}
