using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public interface IBuilds
  {
    Builds GetFields(string fields);
    List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastSuccessfulBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    List<Build> FailedBuildsByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastFailedBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    List<Build> ErrorBuildsByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastErrorBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastBuildByAgent(string agentName, List<String> param = null);
    Build ById(string id);
    List<Build> ByBuildConfigId(string buildConfigId);
    List<Build> RunningByBuildConfigId(string buildConfigId);
    List<Build> ByBuildConfigId(string buildConfigId, List<String> param);
    List<Build> ByBuildLocator(BuildLocator locator, List<String> param);
    List<Build> ByConfigIdAndTag(string buildConfigId, string tag);
    List<Build> ByUserName(string userName);
    List<Build> ByBuildLocator(BuildLocator locator);
    List<Build> AllSinceDate(DateTime date, long count = 100, List<string> param = null);
    List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
    List<Build> NonSuccessfulBuildsForUser(string userName);
    List<Build> ByBranch(string branchName);
    void Add2QueueBuildByBuildConfigId(string buildConfigId);
    List<Build> AllRunningBuild();
    List<Build> RetrieveEntireBuildChainFrom(string buildConfigId, bool includeInitial = true, List<string> param = null);
    List<Build> RetrieveEntireBuildChainTo(string buildConfigId, bool includeInitial = true, List<string> param = null);
    List<Build> NextBuilds(string buildid, long count = 100, List<string> param = null);
    List<Build> AffectedProject(string projectId, long count = 100, List<string> param = null);
    void DownloadLogs(string projectId, bool zipped, Action<string> downloadHandler);
  }
}
