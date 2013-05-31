using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HostSwitchLib;

namespace HostSwitchLib
{
    public class Server
    {
        HostSwitchConfig config = new HostSwitchConfig();

        public string GetHostFileContent()
        {
            if (System.IO.File.Exists(config.HostDefaultPath))
                return System.IO.File.ReadAllText(config.HostDefaultPath, Encoding.GetEncoding("gb2312"));
            return "";
        }

        public bool SwitchHostContent(string content)
        {
            System.IO.File.WriteAllText(config.HostDefaultPath, content, Encoding.GetEncoding("gb2312"));
            return true;
        }

        public bool RecordCurrentHostKey(string key)
        {
            System.IO.File.WriteAllText(config.ConfigFilePath, key, Encoding.UTF8);
            return true;
        }

        public string ReadCurrentHostKey()
        {
            return System.IO.File.ReadAllText(config.ConfigFilePath, Encoding.UTF8);
        }

        static Server server = new Server();
        public static Server GetInstance()
        {
            return server; 
        }
    }
}
