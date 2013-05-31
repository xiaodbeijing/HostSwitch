using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HostSwitchLib;

namespace HostSwitchTest
{
    [TestClass]
    public class HostManagerFactoryTest
    {
        public void GetInstanceTest()
        {
            IHostManager manager = HostManagerFactory.GetInstance();
            Assert.IsNotNull(manager);
            Assert.IsTrue(manager is HostManager);

            manager = HostManagerFactory.GetInstance(new HostSwitchConfig());
            Assert.IsNotNull(manager);
            Assert.IsTrue(manager is HostManager);
        }


    }
}
