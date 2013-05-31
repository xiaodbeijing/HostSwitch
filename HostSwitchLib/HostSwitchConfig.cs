using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib
{
    public class HostSwitchConfig : HostSwitchLib.IHostSwitchConfig
    {
        virtual public string HostFileSavePath
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["FileSavePath"] + "HostFile";
            }
        }

        virtual public string ConfigFilePath
        {
            get
            {
                return System.Configuration.ConfigurationSettings.AppSettings["FileSavePath"] + "Config\\config.ini";
            }
        }

        virtual public string DefaultId
        {
            get
            {
                return System.Environment.SystemDirectory + "\\etc\\drivers\\hosts";
            }
        }

        /// <summary>
        /// host文件路径
        /// </summary>
        virtual public string HostDefaultPath
        {
            get
            {
                return System.IO.Path.Combine(
                    System.Environment.SystemDirectory, @"drivers\etc\hosts");
            }
        }
    }
}
