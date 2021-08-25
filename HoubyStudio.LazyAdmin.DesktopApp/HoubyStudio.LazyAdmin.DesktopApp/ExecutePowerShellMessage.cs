using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    public class ExecutePowerShellMessage : WebViewMessage
    {
        // TODO: Create command class containing command, parameters, common parameters etc.
        // TODO: Create list of command classes here to be iritated and added to ps command stack
        private string _command;

        public string Command
        {
            set => _command = value;
            get => _command;
        }
    }
}
