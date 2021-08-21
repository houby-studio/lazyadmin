using Microsoft.Web.WebView2.Core;
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
        ///// <summary>
        ///// Resolves to the full path of the user data folder for WebView2 component.
        ///// </summary>
        ///// <returns> Usually the returned folder path will conform to this format:
        ///// <c>C:\Users\{username}\AppData\Local\LazyAdmin</c></returns>
        //private readonly string _cacheFolderPath;

        ///// <summary>
        ///// Resolves to the index.html file, which gets rendered by WebView2 component.
        ///// </summary>
        ///// <returns> Usually the returned file path will conform to this format:
        ///// <c>C:\Users\{username}\AppData\Local\LazyAdmin\EBWebView\WebResources\index.html</c></returns>
        //private readonly Uri _indexFilePath;

        // TEST
        //private readonly HostMessageHandler _cSharpBridge = new HostMessageHandler();
        //private readonly LazyAdminPowerShell _webViewBridge = new LazyAdminPowerShell();

        public MainWindow()
        {
            // Required. Loads the compiled page of a component from XAML.
            InitializeComponent();

            // TODO: Move to WebViewController
            // Resolve full path to user data folder
            //_cacheFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin");
            // Resolve full path to index.html file served by WebView2 control.
            //_indexFilePath = new Uri(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin/EBWebView/WebResources/index.html"));

            // Map webView generated from XAML to WebViewController, which initializes component.
            LazyAdminWebView.WebView = webView;
            
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            try
            {
                // Create new environment configuration pointing to correct User Data Folder
                //CoreWebView2Environment webView2Environment = await CoreWebView2Environment.CreateAsync(null, _cacheFolderPath);
                LazyAdminWebView.InitializeWebView();

                // TEST
                //webView.CoreWebView2.WebMessageReceived += UpdateTextBox;
                //await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
                //await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");

                // TODO: Check if _indexFilePath file exists and if not, try to download it from Github.
                //webView.Source = new UriBuilder(_indexFilePath).Uri;
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
            MessageBox.Show(this, message, caption);
            Application.Current.Shutdown();
        }

        //// TEST
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //_cSharpBridge.Message = TextBox.Text;
        //    //_cSharpBridge.ShowMessage();
        //    LazyAdminWebView.ShowMessage(TextBox.Text);
        //}

        //// TEST
        //private void UpdateTextBox(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        //{
        //    String uri = args.TryGetWebMessageAsString();
        //    TextBox.Text = uri;
        //    _webViewBridge.Message = uri;
        //    _webViewBridge.ShowMessage();

        //}
    }
}
