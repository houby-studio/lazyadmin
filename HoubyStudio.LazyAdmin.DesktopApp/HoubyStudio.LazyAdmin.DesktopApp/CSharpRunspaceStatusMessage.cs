// <copyright file="CSharpRunspaceStatusMessage.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CSharpRunspaceStatusMessage : CSharpMessage
    {
        public string Type { set; get; }
        public string Status { set; get; }
        public string Result { set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpRunspaceStatusMessage"/> class.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="status"></param>
        /// <param name="result"></param>
        public CSharpRunspaceStatusMessage(Guid uid, string status, string result)
        {
            this.Type = "runespacestatus";
            this.Uid = uid;
            this.Status = status;
            this.Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CSharpRunspaceStatusMessage"/> class.
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="status"></param>
        public CSharpRunspaceStatusMessage(Guid uid, string status)
        {
            this.Type = "runespacestatus";
            this.Uid = uid;
            this.Status = status;
        }
    }
}
