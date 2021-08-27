using Microsoft.Web.WebView2.Wpf;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp.Web.Services
{
    /// <summary>
    /// WebView service interface
    /// </summary>
    public interface IWebViewService
    {
        Task<string> ShowMessageAsync(string message);
    }
}
