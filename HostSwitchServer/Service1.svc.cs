using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HostSwitchLib;

namespace HostSwitchServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        HostSwitchConfig config = new HostSwitchConfig();

        private string UserName
        {
            get
            {
                //return System.ServiceModel.ServiceSecurityContext.Current.WindowsIdentity.Name;
                return "dongbo";
            }
        }

        private string Pwd { get; set; }

        private IHostSwitchConfig GetCurrentUser(string userName, string pwd)
        {
            HostManagerServer hms = new HostManagerServer(new ServerHostSwitchConfig(userName));
            if (!hms.UserDirectoryIsExists(userName))
                hms.InitUserDirectoryInfo(userName);
            return new ServerHostSwitchConfig(userName);
        }

        public bool BackDefaultHost(string content)
        {
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).BackDefaultHost(content);
        }

        public bool WriteHostContent(string key, string content)
        {
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).WriteHostContent(key, content);
        }

        public string ReadHostContent(string key)
        {
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).ReadHostContent(key);
        }

        public bool CreateHostContent(string key){
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).CreateHostContent(key);
        }

        public List<HostItem> GetHostList()
        {
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).GetHostList();
        }

        public bool RenameHostContent(string p, string p_2)
        {
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).RenameHostContent(p,p_2);
        }

        public void DeleteHostContent(string p)
        {
            HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).DeleteHostContent(p);
        }

        public bool FileExists(string key)
        {
            return HostManagerFactory.GetInstance(GetCurrentUser(UserName, Pwd)).FileExists(key);
        }
    }
}
