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

        public MainWindow()
        {
            // Required. Loads the compiled page of a component from XAML.
            InitializeComponent();

            // Map webView generated from XAML to LazyAdminWebView, which initializes component.
            LazyAdminWebView.WebView = webView;

            // TEST: Map mock PowerShell (TextBox) from XAML to 
            LazyAdminPowerShell.PowerShell = PowerShell;
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
    }
}
