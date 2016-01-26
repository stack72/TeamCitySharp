using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public interface IBuilds
  {
    Builds GetFields(string fields);
    List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId);
    List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId, List<String> param);
    Build LastSuccessfulBuildByBuildConfigId(string buildConfigId);
    List<Build> FailedBuildsByBuildConfigId(string buildConfigId);
    Build LastFailedBuildByBuildConfigId(string buildConfigId);
    Build LastBuildByBuildConfigId(string buildConfigId);
    List<Build> ErrorBuildsByBuildConfigId(string buildConfigId);
    Build LastErrorBuildByBuildConfigId(string buildConfigId);
    Build ById(string id);
    List<Build> ByBuildConfigId(string buildConfigId);
    List<Build> RunningByBuildConfigId(string buildConfigId);
    List<Build> ByBuildConfigId(string buildConfigId, List<String> param);
    List<Build> ByBuildLocator(BuildLocator locator, List<String> param);
    List<Build> ByConfigIdAndTag(string buildConfigId, string tag);
    List<Build> ByUserName(string userName);
    List<Build> ByBuildLocator(BuildLocator locator);
    List<Build> AllSinceDate(DateTime date);
    List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
    List<Build> NonSuccessfulBuildsForUser(string userName);
    List<Build> ByBranch(string branchName);
    Build LastBuildByAgent(string agentName);
    void Add2QueueBuildByBuildConfigId(string buildConfigId);
    List<Build> AllRunningBuild();
    List<Build> RetrieveEntireBuildChainFrom(string buildConfigId);
    List<Build> RetrieveEntireBuildChainTo(string buildConfigId);
  }
}