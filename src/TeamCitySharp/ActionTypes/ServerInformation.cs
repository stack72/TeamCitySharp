﻿namespace TeamCitySharp.ActionTypes
{
    using System.Collections.Generic;
    using System.Text;
    using TeamCitySharp.Connection;
    using TeamCitySharp.DomainEntities;

    internal class ServerInformation : IServerInformation
    {
        private const string ServerUrlPrefix = "/app/rest/server";
        private readonly ITeamCityCaller _caller;

        internal ServerInformation(ITeamCityCaller caller)
        {
            _caller = caller;
        }

        public Server ServerInfo()
        {
            var server = _caller.Get<Server>(ServerUrlPrefix);
            return server;
        }

        public List<Plugin> AllPlugins()
        {
            var pluginWrapper = _caller.Get<PluginWrapper>(ServerUrlPrefix + "/plugins");

            return pluginWrapper.Plugin;
        }

        public bool TriggerServerInstanceBackup(string fileName)
        {
            var url = string.Format(ServerUrlPrefix + "/backup?fileName={0}&includeConfigs=true&includeDatabase=true&includeBuildLogs=false", fileName);
            string backupFilename = _caller.StartBackup(url);

            return !string.IsNullOrEmpty(backupFilename);
        }

        public string TriggerServerInstanceBackup(BackupOptions backupOptions)
        {
            var backupOptionsUrlPart = this.BuildBackupOptionsUrl(backupOptions);
            var url = string.Concat(ServerUrlPrefix, "/backup?", backupOptionsUrlPart);

            return _caller.StartBackup(url);
        }

        public string GetBackupStatus()
        {
            var url = string.Concat(ServerUrlPrefix, "/backup");

            return _caller.GetRaw(url);
        }

        private string BuildBackupOptionsUrl(BackupOptions backupOptions)
        {
            return new StringBuilder()
                .Append("fileName=").Append(backupOptions.Filename)
                .Append("&includeBuildLogs=").Append(backupOptions.IncludeBuildLogs)
                .Append("&includeConfigs=").Append(backupOptions.IncludeConfigurations)
                .Append("&includeDatabase=").Append(backupOptions.IncludeDatabase)
                .Append("&includePersonalChanges=").Append(backupOptions.IncludePersonalChanges)
                .ToString();
        }
    }
}