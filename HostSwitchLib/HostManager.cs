using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostSwitchLib
{
    public class HostManager : HostSwitchLib.IHostManager
    {
        public const string DefaultHostFileName = "默认HOST文件";

        public bool BackDefaultHost(string content)
        {
            string defaultFilePath = GetFileSavePath(DefaultHostFileName);
            System.IO.File.WriteAllText(defaultFilePath,content);
            return true;
        }

        public bool WriteHostContent(string key, string content)
        {
            string path = GetFileSavePath(key);
            if (!System.IO.File.Exists(path))
                throw new ArgumentException("指定HOST名不存在");
            System.IO.File.WriteAllText(path,content);
            return true;
        }

        public string ReadHostContent(string key)
        {
            return _GetHostContent(key);
        }

        private IHostSwitchConfig config;

        public HostManager(IHostSwitchConfig config)
        {
            // TODO: Complete member initialization
            this.config = config;
        }

        public List<HostItem> GetHostList()
        {
            string[] hList = System.IO.Directory.GetFiles(config.HostFileSavePath, "*.hosts");
            List<HostItem> hostItemList = new List<HostItem>();

            foreach (string key in hList)
            {
                HostItem hi = new HostItem()
                {
                    Key = System.IO.Path.GetFileNameWithoutExtension(key)
                };
                hostItemList.Add(hi);
            }
            return hostItemList;
        }

        private string GetFileSavePath(string key)
        {
            return System.IO.Path.Combine(config.HostFileSavePath, key + ".hosts");
        }

        private string _GetHostContent(string key)
        {
            string defaultFilePath = GetFileSavePath(key);
            if (System.IO.File.Exists(defaultFilePath))
                return System.IO.File.ReadAllText(defaultFilePath);
            return String.Empty;
        }

        

        public bool FileExists(string key)
        {
            string path = GetFileSavePath(key);
            if (System.IO.File.Exists(path))
                return true;
            return false;
        }

        public bool CreateHostContent(string key)
        {
            if(FileExists(key))
                throw new ArgumentException(key + " 这个HOST名已经存在");
            string path = GetFileSavePath(key);
            System.IO.File.WriteAllText(path, "#" + DateTime.Now + " HostSwitch 创建 " + key + "\r\n");
            return true;
        }


        public bool RenameHostContent(string keyold, string keynew)
        {
            if (FileExists(keynew))
                throw new ArgumentException(keynew + "这个HOST名已经存在，不能改名");

            string oldpath = GetFileSavePath(keyold);

            System.IO.File.Copy(
                oldpath, GetFileSavePath(keynew));

            System.IO.File.Delete(oldpath);

            return true;
        }

        public void DeleteHostContent(string key)
        {
            if (!FileExists(key))
                throw new ArgumentException(key + "这个HOST名不存在");
            System.IO.File.Move(GetFileSavePath(key), GetFileSavePath(key).Replace(".hosts",".hosts" + DateTime.Now.Ticks + ".del"));
            //System.IO.File.Delete(GetFileSavePath(key));

        }
    }
}
