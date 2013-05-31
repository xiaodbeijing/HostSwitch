using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib.UI
{

    public class EditMenu : IAppMenuItem
    {
        public event EventHandler EditMenuClick;
        public void ClickEvent(object sender, EventArgs e)
        {
            if(EditMenuClick != null)
                EditMenuClick.Invoke(sender, e);
        }


        public void SetLastMenuItem(object lastSender)
        {
            
        }
    }
}
