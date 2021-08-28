// <copyright file="WebViewMessage.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class WebViewMessage
    {
        private Guid uid;
        private Guid token;

        public Guid Uid
        {
            set => this.uid = value;
            get => this.uid;
        }

        public Guid Token
        {
            set => this.token = value;
            get => this.token;
        }
    }
}
