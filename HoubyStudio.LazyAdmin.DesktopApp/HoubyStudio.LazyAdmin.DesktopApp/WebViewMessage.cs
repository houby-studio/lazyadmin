using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    public class WebViewMessage
    {
        private Guid _uid;
        private Guid _token;

        public Guid Uid
        {
            set => _uid = value;
            get => _uid;
        }

        public Guid Token
        {
            set => _token = value;
            get => _token;
        }
    }
}
