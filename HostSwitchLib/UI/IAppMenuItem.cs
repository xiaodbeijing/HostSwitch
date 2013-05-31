using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib.UI
{
    public interface IAppMenuItem
    {
        void ClickEvent(object sender, EventArgs e);

        void SetLastMenuItem(object lastSender);
    }
}
