using System;
namespace HostSwitchLib
{
    public interface IHostSwitchConfig
    {
        string ConfigFilePath { get; }
        string DefaultId { get; }
        string HostDefaultPath { get; }
        string HostFileSavePath { get; }
    }
}
