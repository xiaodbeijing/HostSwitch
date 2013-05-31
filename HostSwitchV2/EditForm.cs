using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HostSwitchLib;

namespace HostSwitchV2
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            LastHostKey = null;
            BindHostList();
            this.listView1.Items[0].Selected = true;
        }

        private void BindHostList()
        {
            this.listView1.Clear();
            this.listView1.BeginUpdate();
            List<HostItem> list = HostSwitchLib.HostManagerFactory.GetInstance().GetHostList();
            foreach (HostItem item in list)
            {
                this.listView1.Items.Add(item.Key);
            }
            this.listView1.Items.Add("+新配置");
            this.listView1.EndUpdate();
        }

        static ListViewItem LastHostKey = null;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LastHostKey != null && HostManagerFactory.GetInstance().FileExists(LastHostKey.Text))
                SaveHost(LastHostKey.Text);

            if (this.listView1.SelectedItems.Count == 0)
                return;

            if (this.listView1.SelectedItems[0].Text == "+新配置")
            {
                string newKey = CreateNewContentName();
                this.listView1.SelectedItems[0].Text = newKey;
                SaveNewContent(this.listView1.SelectedItems[0].Text);
                this.BindHostList();
                SelectedKey(newKey);
            }
            else
            {
                LoadHost(this.listView1.SelectedItems[0].Text);
                LastHostKey = this.listView1.SelectedItems[0];
            }
        }

        private void SelectedKey(string newKey)
        {
            ListViewItem selItem = FindKeyItem(newKey);
            if (selItem != null)
                selItem.Selected = true;
        }

        private ListViewItem FindKeyItem(string key)
        {
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.Text == key)
                    return lvi;
            }
            return null;
        }

        private static string CreateNewContentName()
        {
            string temp = DateTime.Now.ToString("yyyyMMdd") + "新配置";
            string ret = temp;
            int tryNum = 0;
            while (HostManagerFactory.GetInstance().FileExists(ret))
            {
                tryNum++;
                ret = temp + "(" + tryNum + ")";
            }
            return ret;
        }

        private void SaveHost(string LastHostKey)
        {
            if (LastHostKey != "")
            {
                HostManagerFactory.GetInstance().WriteHostContent(LastHostKey, this.textBox1.Text);
                if (LastHostKey == Server.GetInstance().ReadCurrentHostKey())
                    Server.GetInstance().SwitchHostContent(this.textBox1.Text);
            }
            
        }

        private void LoadHost(string key)
        {
            this.textBox1.Text = HostManagerFactory.GetInstance().ReadHostContent(key);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHost(this.listView1.SelectedItems[0].Text);
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            if (!RenameContent(listView1.SelectedItems[0].Text, e.Label))
            {
                MessageBox.Show("改名失败，HOST名已经存在或不符合要求。");
                e.CancelEdit = true;
                return;
            }
            this.listView1.SelectedItems[0].Text = e.Label;
        }

        private bool SaveNewContent(string p)
        {
            try
            {
                HostManagerFactory.GetInstance().CreateHostContent(p);
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }

        private bool RenameContent(string p, string p_2)
        {
            try
            {
                HostManagerFactory.GetInstance().RenameHostContent(p, p_2);
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("真的要删除这个配置文件么？", "删除确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    HostManagerFactory.GetInstance().DeleteHostContent(
                        listView1.SelectedItems[0].Text);
                    BindHostList();
                    listView1.Items[0].Selected = true;
                }
            }
        }
    }
}
