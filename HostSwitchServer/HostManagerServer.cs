using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostSwitchLib;

namespace HostSwitchServer
{
    public class HostManagerServer
    {
        IHostSwitchConfig config = null;

        public HostManagerServer(IHostSwitchConfig config)
        {
            this.config = config;
        }

        public bool UserDirectoryIsExists(string userName)
        {
            string userDirectoryPath = config.HostFileSavePath;
            return System.IO.Directory.Exists(userDirectoryPath);
        }

        public bool InitUserDirectoryInfo(string userName)
        {
            if (UserDirectoryIsExists(userName))
                throw new Exception(userName + "用户信息已经存在");

            System.IO.Directory.CreateDirectory(config.HostFileSavePath);
            System.IO.Directory.CreateDirectory(config.HostFileSavePath + "\\HostFile");
            System.IO.Directory.CreateDirectory(config.HostFileSavePath + "\\Config");
            System.IO.File.Create(config.HostFileSavePath + "\\Config\\Config.ini");

            return true;
        }
    }
}