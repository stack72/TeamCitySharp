using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuilds
    {
        List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId);
        Build LastSuccessfulBuildByBuildConfigId(string buildConfigId);
        List<Build> FailedBuildsByBuildConfigId(string buildConfigId);
        Build LastFailedBuildByBuildConfigId(string buildConfigId);
        Build LastBuildByBuildConfigId(string buildConfigId);
        List<Build> ErrorBuildsByBuildConfigId(string buildConfigId);
        Build LastErrorBuildByBuildConfigId(string buildConfigId);
        List<Build> BuildConfigsByBuildConfigId(string buildConfigId);
        List<Build> BuildConfigsByConfigIdAndTag(string buildConfigId, string tag);
        List<Build> BuildsByUserName(string userName);
        List<Build> BuildsByBuildLocator(BuildLocator locator);
        List<Build> AllBuildsSinceDate(DateTime date);
        List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
        List<Build> NonSuccessfulBuildsForUser(string userName);
        Build LastBuildByAgent(string agentName);
    }
}