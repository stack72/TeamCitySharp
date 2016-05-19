using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public interface IServerInformation
  {
    Server ServerInfo();
    List<Plugin> AllPlugins();
    string TriggerServerInstanceBackup(BackupOptions backupOptions);
    string GetBackupStatus();
  }
}