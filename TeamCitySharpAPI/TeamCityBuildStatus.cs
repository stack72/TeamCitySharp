using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface TeamCityBuildStatus: ClientConnection
    {
        List<Build> GetSuccessfulBuildsByProjectName(string projectName);
        Build GetLastSuccessfulBuildByProjectName(string projectName);

        List<Build> GetCancelledBuildsByProjectName(string projectName);
        Build GetLastCancelledBuildByProjectName(string projectName);
    }
}