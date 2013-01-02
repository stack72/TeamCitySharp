using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class Builds : IBuilds
    {
        private readonly TeamCityCaller _caller;

        internal Builds(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<Build> BuildsByBuildLocator(BuildLocator locator)
        {
            var buildWrapper = _caller.GetFormat<BuildWrapper>("/app/rest/builds?locator={0}", locator);
            if (int.Parse(buildWrapper.Count) > 0)
            {
                return buildWrapper.Build;
            }
            return new List<Build>();
        }

        public Build LastBuildByAgent(string agentName)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(
                agentName: agentName,
                maxResults: 1
                                            )).SingleOrDefault();
        }

        public List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.SUCCESS
                                            ));
        }

        public Build LastSuccessfulBuildByBuildConfigId(string buildConfigId)
        {
            var builds = BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.SUCCESS,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<Build> FailedBuildsByBuildConfigId(string buildConfigId)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.FAILURE
                                            ));
        }

        public Build LastFailedBuildByBuildConfigId(string buildConfigId)
        {
            var builds = BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.FAILURE,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public Build LastBuildByBuildConfigId(string buildConfigId)
        {
            var builds = BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<Build> ErrorBuildsByBuildConfigId(string buildConfigId)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.ERROR
                                            ));
        }

        public Build LastErrorBuildByBuildConfigId(string buildConfigId)
        {
            var builds = BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.ERROR,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<Build> BuildConfigsByBuildConfigId(string buildConfigId)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)
                                            ));
        }

        public List<Build> BuildConfigsByConfigIdAndTag(string buildConfigId, string tag)
        {
            return BuildConfigsByConfigIdAndTag(buildConfigId, new[] { tag });
        }

        public List<Build> BuildConfigsByConfigIdAndTag(string buildConfigId, string[] tags)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    tags: tags
                                            ));
        }

        public List<Build> BuildsByUserName(string userName)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(
                user: UserLocator.WithUserName(userName)
                                            ));
        }

        public List<Build> AllBuildsSinceDate(DateTime date)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(sinceDate: date));
        }

        public List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(sinceDate: date, status: buildStatus));
        }

        public List<Build> NonSuccessfulBuildsForUser(string userName)
        {
            var builds = BuildsByUserName(userName);
            if (builds == null)
            {
                return null;
            }

            return builds.Where(b => b.Status != "SUCCESS").ToList();
        }
    }
}