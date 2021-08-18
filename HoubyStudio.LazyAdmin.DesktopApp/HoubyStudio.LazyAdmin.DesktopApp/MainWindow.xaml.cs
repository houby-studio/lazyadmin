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
        /// <summary>
        /// Resolves to the full path of the user data folder for WebView2 component.
        /// </summary>
        /// <returns> Usually the returned folder path will conform to this format:
        /// <c>C:\Users\{username}\AppData\Local\LazyAdmin</c></returns>
        private readonly string _cacheFolderPath;

        /// <summary>
        /// Resolves to the index.html file, which gets rendered by WebView2 component.
        /// </summary>
        /// <returns> Usually the returned file path will conform to this format:
        /// <c>C:\Users\{username}\AppData\Local\LazyAdmin\EBWebView\WebResources\index.html</c></returns>
        private readonly Uri _indexFilePath;

        public MainWindow()
        {
            InitializeComponent();

            _cacheFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin");
            _indexFilePath = new Uri(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LazyAdmin/EBWebView/WebResources/index.html"));
        }

        protected override async void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            try
            {
                // Create new environment configuration pointing to correct User Data Folder
                CoreWebView2Environment webView2Environment = await CoreWebView2Environment.CreateAsync(null, _cacheFolderPath);
                await webView.EnsureCoreWebView2Async(webView2Environment);

                // TODO: Check if _indexFilePath file exists and if not, try to download it from Github.
                webView.Source = new UriBuilder(_indexFilePath).Uri;
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

    }
}
