﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class Builds : IBuilds
    {
        private readonly ITeamCityCaller _caller;

        internal Builds(ITeamCityCaller caller)
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

        public List<Build> ByBuildLocator(BuildLocator locator, Action<BuildPropertyBuilder> buildProperties)
        {
            var buildPropertyBuilder = new BuildPropertyBuilder();
            buildProperties.Invoke(buildPropertyBuilder);
            var buildPropertiesList = buildPropertyBuilder.GetBuildPropertiesList();

            var buildWrapper = _caller.GetFormat<BuildWrapper>("/app/rest/builds?locator={0}&fields=count,build({1})", locator.ToString(), buildPropertiesList);
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

        public Build BuildById(long buildId)
        {
            Build build = _caller.GetFormat<Build>("/app/rest/builds/id:{0}", buildId);
            if (build.LastChanges == null)
            {
                if (build.Changes.Count == 0)
                {
                    build.LastChanges = new ChangesList();
                    return build;
                }
                build.LastChanges = _caller.GetByFullUrl<ChangesList>(build.Changes.Href);
            }
            return build;
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

    public class BuildPropertyBuilder
    {
        readonly IList<string> m_Properties = new List<string>(new[]
        {
            "buildTypeId", "href", "id", "number", "state", "status","webUrl"
        });

        internal string GetBuildPropertiesList()
        {
            return string.Join(",", m_Properties);
        }

        public BuildPropertyBuilder IncludeStartDate()
        {
            return IncludeProperty();
        }

        public BuildPropertyBuilder IncludeFinishDate()
        {
            return IncludeProperty();
        }

        public BuildPropertyBuilder IncludeStatusText()
        {
            return IncludeProperty();
        }

        private BuildPropertyBuilder IncludeProperty()
        {
            var methodName = new StackFrame(1).GetMethod().Name.Remove(0,7);
            m_Properties.Add(methodName.FirstCharacterToLower());
            return this;
        }
    }
}