using System;
namespace HostSwitchLib
{
    public interface IHostManager
    {
        bool BackDefaultHost(string content);
        System.Collections.Generic.List<HostItem> GetHostList();
        string ReadHostContent(string key);
        bool WriteHostContent(string key, string content);

        bool CreateHostContent(string p);

        bool RenameHostContent(string p, string p_2);

        void DeleteHostContent(string p);

        bool FileExists(string key);
    }
}
