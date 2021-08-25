using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    public class CSharpRunspaceStatusMessage : CSharpMessage
    {
        public string Type { set; get; }
        public string Status { set; get; }
        public string Result { set; get; }

        public CSharpRunspaceStatusMessage(Guid uid, string status, string result)
        {
            Type = "runespacestatus";
            Uid = uid;
            Status = status;
            Result = result;
        }

        public CSharpRunspaceStatusMessage(Guid uid, string status)
        {
            Type = "runespacestatus";
            Uid = uid;
            Status = status;
        }
    }
}
