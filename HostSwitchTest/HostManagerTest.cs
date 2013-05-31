using HostSwitchLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace HostSwitchTest
{
    [TestClass]
    public class HostManagerTest
    {

        [TestMethod]
        public void GetHostList()
        {
            List<HostItem> list = HostManagerFactory.GetInstance().GetHostList();
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void SwitchHost()
        {
            bool ret = Server.GetInstance().SwitchHostContent("abcdef");
            Assert.IsTrue(ret);

            string defaultContent = Server.GetInstance().GetHostFileContent();
            Assert.AreEqual("abcdef",defaultContent);
        }

        [TestMethod]
        public void BackUpAndGetDefaultHost()
        {
            string ruleContent = Server.GetInstance().GetHostFileContent();
            
            bool ret = HostManagerFactory.GetInstance().BackDefaultHost(ruleContent);
            Assert.IsTrue(ret);

            string dHost = HostManagerFactory.GetInstance().ReadHostContent(HostManager.DefaultHostFileName);
            Assert.AreEqual(ruleContent, dHost);
        }

        [TestMethod]
        public void ReadHostContent()
        {
            HostManagerFactory.GetInstance().WriteHostContent("key", "testHost");
            string hContent = HostManagerFactory.GetInstance().ReadHostContent("key");
            Assert.IsNotNull(hContent);

            Assert.AreEqual(String.Empty,
                HostManagerFactory.GetInstance().ReadHostContent(Guid.NewGuid().ToString()));
        }

        [TestMethod]
        public void WriteHostContent()
        {
            if (!HostManagerFactory.GetInstance().FileExists("key"))
                HostManagerFactory.GetInstance().CreateHostContent("key");
            bool ret = HostManagerFactory.GetInstance().WriteHostContent("key", "abcdef");
            Assert.IsTrue(ret);

            string c = HostManagerFactory.GetInstance().ReadHostContent("key");
            Assert.AreEqual("abcdef",c);

            try
            {
                HostManagerFactory.GetInstance().WriteHostContent(Guid.NewGuid().ToString(), "");
                Assert.Fail("创建一个不存在的HOST文件，请用createHostContent函数");
            }
            catch (Exception ee)
            {
            }
        }

        [TestMethod]
        public void CreateHostContent()
        {
            try
            {
                bool ret = HostManagerFactory.GetInstance().CreateHostContent("key");
                HostManagerFactory.GetInstance().CreateHostContent("key");
                Assert.Fail("不能重复创建HOST文件");
            }
            catch (Exception ee)
            {
                //
            }

            Assert.IsNotNull(HostManagerFactory.GetInstance().ReadHostContent("key"));
        }

        [TestMethod]
        public void FileExistsTest()
        {
            Guid fid = Guid.NewGuid();
            HostManagerFactory.GetInstance().CreateHostContent(fid.ToString());
            HostManagerFactory.GetInstance().FileExists(fid.ToString());
        }

        [TestMethod]
        public void RenameHostContent()
        {
            try
            {
                HostManagerFactory.GetInstance().CreateHostContent("key");
            }
            catch
            {
            }

            bool ret = HostManagerFactory.GetInstance().RenameHostContent("key", "key1");
            Assert.IsTrue(ret);

            Assert.IsNotNull(
                HostManagerFactory.GetInstance().ReadHostContent("key1"));
            try
            {
                HostManagerFactory.GetInstance().RenameHostContent("key1", "key1");
                Assert.Fail("不能改名为一个已经存在的文件");
            }
            catch
            {

            }
            finally
            {
                HostManagerFactory.GetInstance().DeleteHostContent("key1");
            }

        }
    }
}
