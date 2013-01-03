using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
    internal class ServerInformation : IServerInformation
    {
        private readonly TeamCityCaller _caller;

        internal ServerInformation(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public Server ServerInfo()
        {
            var server = _caller.Get<Server>("/app/rest/server");
            return server;
        }

        public List<Plugin> AllPlugins()
        {
            var pluginWrapper = _caller.Get<PluginWrapper>("/app/rest/server/plugins");

            return pluginWrapper.Plugin;
        }

        public bool TriggerServerInstanceBackup(string fileName)
        {
            var url = string.Format("/app/rest/server/backup?fileName={0}&includeConfigs=true&includeDatabase=true&includeBuildLogs=false", fileName);
            return _caller.StartBackup(url);
        }
    }
}