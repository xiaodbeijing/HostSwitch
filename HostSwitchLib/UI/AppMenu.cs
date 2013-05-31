using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HostSwitchLib.UI
{
    public class AppMenu
    {
        List<System.Windows.Forms.ToolStripItem> menuList = new List<System.Windows.Forms.ToolStripItem>();

        private void AddMenuItem(System.Windows.Forms.ToolStripItem item)
        {
            menuList.Add(item);
        }

        static public AppMenu CreateAppMenu()
        {
            return new AppMenu();
        }
        public AppMenu Builder(string itemName)
        {
            if (itemName == "-")
                AddMenuItem(new System.Windows.Forms.ToolStripSeparator());
            else
                AddMenuItem(new System.Windows.Forms.ToolStripMenuItem(itemName));
            return this;
        }

        public AppMenu Builder(List<HostItem> list, IAppMenuItem hostSelected,string currentKey)
        {
            foreach (HostItem hi in list)
            {
                System.Windows.Forms.ToolStripMenuItem menuItem = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Text = hi.Key,
                    Tag = hi.Key,
                };

                if (hi.Key == currentKey)
                {
                    menuItem.Checked = true;
                    hostSelected.SetLastMenuItem(menuItem);
                }
                menuItem.Click += new EventHandler(hostSelected.ClickEvent);
                AddMenuItem(menuItem);
            }
            return this;
        }


        public AppMenu Builder(string p, IAppMenuItem itemMenu)
        {
            System.Windows.Forms.ToolStripMenuItem menuItem = new System.Windows.Forms.ToolStripMenuItem()
            {
                Text = p
            };
            menuItem.Click += new EventHandler(itemMenu.ClickEvent);
            AddMenuItem(menuItem);
            return this;
        }

        public List<System.Windows.Forms.ToolStripItem> ToMenuList()
        {
            return this.menuList;
        }
    }
}
