using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    public interface IServerInformation
    {
        Server ServerInfo();
        List<Plugin> AllPlugins();
        bool TriggerServerInstanceBackup(string fileName);
    }
}