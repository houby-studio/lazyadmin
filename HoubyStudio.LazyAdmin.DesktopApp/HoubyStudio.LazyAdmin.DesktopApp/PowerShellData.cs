// <copyright file="PowerShellData.cs" company="Houby Studio">
// Copyright (c) Houby Studio. All rights reserved.
// </copyright>

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PowerShellData
    {
        public DateTime Date { get; set; }
        public string Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellData"/> class.
        /// </summary>
        /// <param name="data"></param>
        public PowerShellData(string data)
        {
            this.Date = DateTime.Now;
            this.Data = data;
        }
    }
}
