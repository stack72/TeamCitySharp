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

        public List<Build> ByBuildLocator(BuildLocator locator)
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
            return ByBuildLocator(BuildLocator.WithDimensions(
                agentName: agentName,
                maxResults: 1
                                            )).SingleOrDefault();
        }

        public void Add2QueueBuildByBuildConfigId(string buildConfigId)
        {
            _caller.GetFormat("/action.html?add2Queue={0}", buildConfigId);
        }

        public List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.SUCCESS
                                            ));
        }

        public Build LastSuccessfulBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.SUCCESS,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<Build> FailedBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.FAILURE
                                            ));
        }

        public Build LastFailedBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.FAILURE,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public Build LastBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<Build> ErrorBuildsByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    status: BuildStatus.ERROR
                                            ));
        }

        public Build LastErrorBuildByBuildConfigId(string buildConfigId)
        {
            var builds = ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                          status: BuildStatus.ERROR,
                                                                          maxResults: 1
                                                  ));
            return builds != null ? builds.FirstOrDefault() : new Build();
        }

        public List<Build> ByBuildConfigId(string buildConfigId)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId)
                                            ));
        }

        public List<Build> ByConfigIdAndTag(string buildConfigId, string tag)
        {
            return ByConfigIdAndTag(buildConfigId, new[] { tag });
        }

        public List<Build> ByConfigIdAndTag(string buildConfigId, string[] tags)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(BuildTypeLocator.WithId(buildConfigId),
                                                                    tags: tags
                                            ));
        }

        public List<Build> ByUserName(string userName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(
                user: UserLocator.WithUserName(userName)
                                            ));
        }

        public List<Build> AllSinceDate(DateTime date)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date));
        }

        public List<Build> ByBranch(string branchName)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(branch: branchName));
        } 

        public List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus)
        {
            return ByBuildLocator(BuildLocator.WithDimensions(sinceDate: date, status: buildStatus));
        }

        public List<Build> NonSuccessfulBuildsForUser(string userName)
        {
            var builds = ByUserName(userName);
            if (builds == null)
            {
                return null;
            }

            return builds.Where(b => b.Status != "SUCCESS").ToList();
        }
    }
}