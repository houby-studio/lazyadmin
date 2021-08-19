using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    class WebViewBridgeToCSharp
    {
        public string Message { get; set; }

        public void ShowMessage()
        {
            System.Windows.MessageBox.Show(Message);
        }
    }
}
