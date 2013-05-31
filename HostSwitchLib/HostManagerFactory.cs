using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib
{
    public class HostManagerFactory
    {

        public static IHostManager GetInstance()
        {
            if (GetUserServerMode() != null &&
                GetUserServerMode().ToLower() == "true")
                return new HostManagerClient();
            return new HostManager(new HostSwitchConfig());
        }

        private static string GetUserServerMode()
        {
            return System.Configuration.ConfigurationSettings.AppSettings["UserSeverMode"];
        }

        public static IHostManager GetInstance(IHostSwitchConfig config)
        {
            return new HostManager(config);
        }
    }
}
