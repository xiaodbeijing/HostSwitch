using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostSwitchLib
{
    public class ServerHostSwitchConfig : HostSwitchLib.IHostSwitchConfig
    {
        string userName = "";
        public ServerHostSwitchConfig(string userName)
        {
            this.userName = userName;
        }

        public string HostFileSavePath
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["FileSavePath"] + userName + "\\" + "HostFile";
            }
        }

        public string ConfigFilePath
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["FileSavePath"] + userName + "\\" + "Config\\config.ini";
            }
        }

        public string DefaultId
        {
            get
            {
                return System.Environment.SystemDirectory + "\\etc\\drivers\\hosts";
            }
        }

        /// <summary>
        /// host文件路径
        /// </summary>
        public string HostDefaultPath
        {
            get
            {
                return System.IO.Path.Combine(
                    System.Environment.SystemDirectory, @"drivers\etc\hosts");
            }
        }
    }
}