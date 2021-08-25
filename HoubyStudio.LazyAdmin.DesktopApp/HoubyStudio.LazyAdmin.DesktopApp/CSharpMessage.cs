using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoubyStudio.LazyAdmin.DesktopApp
{
    public class CSharpMessage
    {
        private Guid _uid;

        public Guid Uid
        {
            set => _uid = value;
            get => _uid;
        }
    }
}
