using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp.Models
{
    class Message
    {
        private Guid _token;

        public Guid Token
        {
            set => _token = value;
            get => _token;
        }

        public Message()
        {
            // PowerShell does not send token to javascript
        }

        public Message(Guid token)
        {
            // Javascript sends token to validate source
            Token = token;
        }
    }
}
