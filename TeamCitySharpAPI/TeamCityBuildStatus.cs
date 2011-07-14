using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface TeamCityBuildStatus: ClientConnection
    {
        List<Build> GetSuccessfulBuildsByBuildConfigName(string buildConfigName);
        Build GetLastSuccessfulBuildByBuildConfigName(string buildConfigName);

        List<Build> GetCancelledBuildsByBuildConfigName(string buildConfigName);
        Build GetLastCancelledBuildByBuildConfigName(string buildConfigName);

        List<Build> GetFailedBuildsByBuildConfigName(string buildConfigName);
        Build GetLastFailedBuildByBuildConfigName(string buildConfigName);

        Build GetLastBuildStatusByBuildConfigName(string buildConfigName);

        List<Build> GetErrorBuildsByBuildConfigName(string buildConfigName);
        Build GetLastErrorBuildByBuildConfigName(string buildConfigName);
    }
}