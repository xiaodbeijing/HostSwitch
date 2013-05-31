using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HostSwitchLib.UI;
using HostSwitchLib;

namespace HostSwitchTest
{
    [TestClass]
    public class AppMenuTest
    {

        [TestMethod]
        public void BuilderTest()
        {
            List<HostItem> hostList = new List<HostItem>();
            hostList.Add(new HostItem()
            {
                Key = "默认HOST"
            });

            List<System.Windows.Forms.ToolStripItem> list = AppMenu.CreateAppMenu().
                Builder(hostList, new HostSelected(),"test").
                Builder("-").
                Builder("编辑", new EditMenu()).
                Builder("退出",new ExitMenu()).ToMenuList();
            
            Assert.AreEqual(4,list.Count);
            Assert.AreEqual(list[0].Text,"默认HOST");
            Assert.IsTrue(list[1] is System.Windows.Forms.ToolStripSeparator);
            Assert.AreEqual(list[2].Text, "编辑");
            Assert.AreEqual(list[3].Text, "退出");
        }
    }
}
