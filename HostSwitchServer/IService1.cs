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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool BackDefaultHost(string content);

        [OperationContract]
        bool WriteHostContent(string key, string content);

        [OperationContract]
        string ReadHostContent(string key);

        [OperationContract]
        bool CreateHostContent(string key);

        [OperationContract]
        List<HostItem> GetHostList();

        [OperationContract]
        bool FileExists(string key);

        [OperationContract]
        bool RenameHostContent(string p, string p_2);

        [OperationContract]
        void DeleteHostContent(string p);
    }
}
