using System;
using System.Windows;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Uri index;

        public string LazyAdminUserDataFolder
        {
            get { return (string)System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TestEdge"); }
        }

        public MainWindow()
        {
            InitializeComponent();
            index = new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "web/spa/index.html"));
            webView.Source = index;
        }

    }
}
