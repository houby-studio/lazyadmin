// <copyright file="Message.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Message
    {
        private Guid token;

        public Guid Token
        {
            set => this.token = value;
            get => this.token;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message()
        {
            // PowerShell does not send token to javascript
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="token"></param>
        public Message(Guid token)
        {
            // Javascript sends token to validate source
            this.Token = token;
        }
    }
}
