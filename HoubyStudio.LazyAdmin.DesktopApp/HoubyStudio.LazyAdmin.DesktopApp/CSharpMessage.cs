// <copyright file="CSharpMessage.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CSharpMessage
    {
        private Guid uid;

        public Guid Uid
        {
            set => this.uid = value;
            get => this.uid;
        }
    }
}
