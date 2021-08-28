// <copyright file="ExecutePowerShellMessage.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExecutePowerShellMessage : WebViewMessage
    {
        // TODO: Create command class containing command, parameters, common parameters etc.
        // TODO: Create list of command classes here to be iritated and added to ps command stack
        private string command;

        public string Command
        {
            set => this.command = value;
            get => this.command;
        }
    }
}
