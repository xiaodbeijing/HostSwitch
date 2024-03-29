﻿using HostSwitchLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HostSwitchTest
{
    
    
    /// <summary>
    ///这是 ServerTest 的测试类，旨在
    ///包含所有 ServerTest 单元测试
    ///</summary>
    [TestClass()]
    public class ServerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Server 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void ServerConstructorTest()
        {
            Server target = new Server();
        }

        /// <summary>
        ///GetHostFileContent 的测试
        ///</summary>
        [TestMethod()]
        public void GetHostFileContentTest()
        {
            Server target = new Server(); // TODO: 初始化为适当的值
            string expected = string.Empty; // TODO: 初始化为适当的值
            string actual;
            actual = target.GetHostFileContent();
            Assert.IsTrue(actual != "");
        }

        /// <summary>
        ///GetInstance 的测试
        ///</summary>
        [TestMethod()]
        public void GetInstanceTest()
        {
            Server expected = null; // TODO: 初始化为适当的值
            Server actual;
            actual = Server.GetInstance();
            Assert.IsNotNull(actual);
        }

        /// <summary>
        ///ReadCurrentHostKey 的测试
        ///</summary>
        [TestMethod()]
        public void ReadCurrentHostKeyTest()
        {
            Server target = new Server(); // TODO: 初始化为适当的值
            string expected = "test"; // TODO: 初始化为适当的值
            string actual;
            target.RecordCurrentHostKey("test");
            actual = target.ReadCurrentHostKey();
            Assert.AreEqual(expected, actual);
        }
    }
}
