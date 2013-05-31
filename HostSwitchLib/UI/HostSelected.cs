using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib.UI
{
    public delegate void HostSelectedClickHandler();
    public class HostSelected : IAppMenuItem
    {
        public event HostSelectedClickHandler HostSelectedClick;

        static System.Windows.Forms.ToolStripMenuItem lastSelectedItem = null;

        public void ClickEvent(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem currentMenuItem = ((System.Windows.Forms.ToolStripMenuItem)sender);

            Server.GetInstance().SwitchHostContent(
                HostManagerFactory.GetInstance().ReadHostContent(
                    currentMenuItem.Text
                ));
            Server.GetInstance().RecordCurrentHostKey(currentMenuItem.Text);
            if (lastSelectedItem != null)
                lastSelectedItem.Checked = false;
            currentMenuItem.Checked = true;
            lastSelectedItem = currentMenuItem;

            if(HostSelectedClick != null)
                HostSelectedClick();
        }


        public void SetLastMenuItem(object lastSender)
        {
            lastSelectedItem = (System.Windows.Forms.ToolStripMenuItem)lastSender;
        }
    }
}
