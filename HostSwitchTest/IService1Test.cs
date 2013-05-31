using HostSwitchLib.HostSwitchServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HostSwitchLib;

namespace HostSwitchTest
{
    
    
    /// <summary>
    ///这是 IService1Test 的测试类，旨在
    ///包含所有 IService1Test 单元测试
    ///</summary>
    [TestClass()]
    public class IService1Test
    {


        [TestMethod]
        public void GetHostList()
        {
            List<HostSwitchLib.HostItem> list = HostManagerClient.GetInstance().GetHostList();
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void BackUpAndGetDefaultHost()
        {
            string ruleContent = Server.GetInstance().GetHostFileContent();

            bool ret = HostManagerClient.GetInstance().BackDefaultHost(ruleContent);
            Assert.IsTrue(ret);

            string dHost = HostManagerClient.GetInstance().ReadHostContent(HostManager.DefaultHostFileName);
            Assert.AreEqual(ruleContent, dHost);
        }

        [TestMethod]
        public void ReadHostContent()
        {
            if (!HostManagerClient.GetInstance().FileExists("key"))
            {
                HostManagerClient.GetInstance().CreateHostContent("key");
            }
            HostManagerClient.GetInstance().WriteHostContent("key", "testHost");
            string hContent = HostManagerClient.GetInstance().ReadHostContent("key");
            Assert.IsNotNull(hContent);

            Assert.AreEqual(String.Empty,
                HostManagerClient.GetInstance().ReadHostContent(Guid.NewGuid().ToString()));
        }

        [TestMethod]
        public void WriteHostContent()
        {
            bool ret = HostManagerClient.GetInstance().WriteHostContent("key", "abcdef");
            Assert.IsTrue(ret);

            string c = HostManagerClient.GetInstance().ReadHostContent("key");
            Assert.AreEqual("abcdef", c);
        }

        [TestMethod]
        public void FileExistsTest()
        {
            Guid fid = Guid.NewGuid();
            HostManagerClient.GetInstance().CreateHostContent(fid.ToString());
            HostManagerClient.GetInstance().FileExists(fid.ToString());
        }
    }
}
