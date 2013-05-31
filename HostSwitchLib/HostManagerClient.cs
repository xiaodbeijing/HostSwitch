using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib
{
    public class HostManagerClient : IHostManager
    {
        HostSwitchServer.Service1Client client = null;

        public HostManagerClient()
        {
            client = new HostSwitchServer.Service1Client();
        }

        public bool BackDefaultHost(string content)
        {
            return client.BackDefaultHost(content);
        }

        public List<HostItem> GetHostList()
        {
            HostSwitchServer.HostItem[] arry = (HostSwitchServer.HostItem[])client.GetHostList();
            List<HostItem> ret = new List<HostItem>();
            foreach (HostSwitchServer.HostItem hi in arry)
            {
                ret.Add(new HostItem()
                {
                    Key = hi.Key
                });
            }
            return ret;
        }

        public string ReadHostContent(string key)
        {
            return client.ReadHostContent(key);
        }

        public bool WriteHostContent(string key, string content)
        {
            return client.WriteHostContent(key, content);
        }

        public static HostManagerClient GetInstance()
        {
            return new HostManagerClient();
        }


        public bool CreateHostContent(string p)
        {
            //return true;
            return client.CreateHostContent(p);
        }


        public bool RenameHostContent(string p, string p_2)
        {
            return client.RenameHostContent(p, p_2);
        }

        public void DeleteHostContent(string p)
        {
            client.DeleteHostContent(p);
        }


        public bool FileExists(string key)
        {
            return client.FileExists(key);
        }
    }
}
