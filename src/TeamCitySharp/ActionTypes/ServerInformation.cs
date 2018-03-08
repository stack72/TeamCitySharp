namespace TeamCitySharp.ActionTypes
{
  using System.Collections.Generic;
  using System.Text;
  using Connection;
  using DomainEntities;

  internal class ServerInformation : IServerInformation
  {
    private const string ServerUrlPrefix = "/app/rest/server";
    private readonly ITeamCityCaller m_caller;

    internal ServerInformation(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public Server ServerInfo()
    {
      var server = m_caller.Get<Server>(ServerUrlPrefix);
      return server;
    }

    public List<Plugin> AllPlugins()
    {
      var pluginWrapper = m_caller.Get<PluginWrapper>(ServerUrlPrefix + "/plugins");

      return pluginWrapper.Plugin;
    }

    public string TriggerServerInstanceBackup(BackupOptions backupOptions)
    {
      var backupOptionsUrlPart = BuildBackupOptionsUrl(backupOptions);
      var url = string.Concat(ServerUrlPrefix, "/backup?", backupOptionsUrlPart);

      return m_caller.StartBackup(url);
    }

    public string GetBackupStatus()
    {
      return m_caller.GetRaw(string.Concat(ServerUrlPrefix, "/backup"));
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