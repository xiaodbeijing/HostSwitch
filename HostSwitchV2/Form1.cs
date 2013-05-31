using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostSwitchLib;
using HostSwitchLib.UI;

namespace HostSwitchV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            ExitMenu exitMenu = new ExitMenu();
            exitMenu.ExitMenuClick += new EventHandler(exitMenu_ExitMenuClick);

            InitializeComponent();

            InitDefaultHost();
            HostSelected hostSelected = CreateHostSelected();
            EditMenu editMenu = CreateEditMenu();

            this.contextMenuStrip1.Items.AddRange(
                AppMenu.CreateAppMenu().
                Builder(HostManagerFactory.GetInstance().GetHostList(),
                    hostSelected,
                    Server.GetInstance().ReadCurrentHostKey()).
                Builder("-").
                Builder("编辑", editMenu).
                Builder("退出", exitMenu).ToMenuList().ToArray()
                );

            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private HostSelected CreateHostSelected()
        {
            HostSelected hostSelected = new HostSelected();
            hostSelected.HostSelectedClick += new HostSelectedClickHandler(hostSelected_HostSelectedClick);

            return hostSelected;
        }

        private EditMenu CreateEditMenu()
        {
            EditMenu editMenu = new EditMenu();
            editMenu.EditMenuClick += new EventHandler(editMenu_EditMenuClick);
            return editMenu;
        }

        void editMenu_EditMenuClick(object sender, EventArgs e)
        {
            EditForm eForm = new EditForm();
            eForm.Show();
        }

        void hostSelected_HostSelectedClick()
        {
            this.notifyIcon1.BalloonTipTitle = "切换成功";
            this.notifyIcon1.BalloonTipText = "文件切换成功，IE浏览器需要重启浏览器才能生效。";
            this.notifyIcon1.ShowBalloonTip(5000);
        }

        private void InitDefaultHost()
        {
            if (HostManagerFactory.GetInstance().ReadHostContent("默认HOST文件") == String.Empty)
            {
                HostManagerFactory.GetInstance().CreateHostContent("默认HOST文件");
                HostManagerFactory.GetInstance().WriteHostContent("默认HOST文件", Server.GetInstance().GetHostFileContent());
                Server.GetInstance().RecordCurrentHostKey("默认HOST文件");
            }
        }

        void exitMenu_ExitMenuClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            EditForm ef = new EditForm();
            ef.Show();
        }
    }
}
