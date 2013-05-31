using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HostSwitchLib.UI;

namespace HostSwitchLib.UI
{
    public delegate void ExitMenuClickHandler();

    public class ExitMenu : IAppMenuItem
    {
        public event EventHandler ExitMenuClick;
        public void ClickEvent(object sender, EventArgs e)
        {
            if (ExitMenuClick != null)
                ExitMenuClick.Invoke(sender,e);
        }



        public void SetLastMenuItem(object lastSender)
        {
            
        }
    }
}
