using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp
{
    public class TeamCityClient : IClientConnection, ITeamCityClient
    {
        private readonly TeamCityCaller _caller;

        public TeamCityClient(string hostName, bool useSsl = false)
        {
            _caller = new TeamCityCaller(hostName, useSsl);
        }

        public void Connect(string userName, string password, bool actAsGuest = false)
        {
            _caller.Connect(userName, password, actAsGuest);
        }

        public bool Authenticate()
        {
            return _caller.Authenticate("/app/rest");
        }

        public List<Project> AllProjects()
        {
            var projectWrapper = _caller.Get<ProjectWrapper>("/app/rest/projects");

            return projectWrapper.Project;
        }

        public Project ProjectByName(string projectLocatorName)
        {
            var project = _caller.GetFormat<Project>("/app/rest/projects/name:{0}", projectLocatorName);

            return project;
        }

        public Project ProjectById(string projectLocatorId)
        {
            var project = _caller.GetFormat<Project>("/app/rest/projects/id:{0}", projectLocatorId);

            return project;
        }

        public Project ProjectDetails(Project project)
        {
            return ProjectById(project.Id);
        }

        public Server ServerInfo()
        {
            var server = _caller.Get<Server>("/app/rest/server");
            return server;
        }

        public List<Plugin> AllServerPlugins()
        {
            var pluginWrapper = _caller.Get<PluginWrapper>("/app/rest/server/plugins");

            return pluginWrapper.Plugin;
        }

        public List<Agent> AllAgents()
        {
            var agentWrapper = _caller.Get<AgentWrapper>("/app/rest/agents");

            return agentWrapper.Agent;
        }

        public List<VcsRoot> AllVcsRoots()
        {
            var vcsRootWrapper = _caller.Get<VcsRootWrapper>("/app/rest/vcs-roots");

            return vcsRootWrapper.VcsRoot;
        }

        public VcsRoot VcsRootById(string vcsRootId)
        {
            var vcsRoot = _caller.GetFormat<VcsRoot>("/app/rest/vcs-roots/id:{0}", vcsRootId);

            return vcsRoot;
        }

        public List<User> AllUsers()
        {
            var userWrapper = _caller.Get<UserWrapper>("/app/rest/users");

            return userWrapper.User;
        }

        public List<Role> AllRolesByUserName(string userName)
        {
            var user =
                _caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

            return user.Roles.Role;
        }

        public List<Group> AllGroupsByUserName(string userName)
        {
            var user =
                _caller.GetFormat<User>("/app/rest/users/username:{0}", userName);

            return user.Groups.Group;
        }

        public List<Group> AllUserGroups()
        {
            var userGroupWrapper = _caller.Get<UserGroupWrapper>("/app/rest/userGroups");

            return userGroupWrapper.Group;
        }

        public List<User> AllUsersByUserGroup(string userGroupName)
        {
            var group = _caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", userGroupName);

            return group.Users.User;
        }

        public List<Role> AllUserRolesByUserGroup(string userGroupName)
        {
            var group = _caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", userGroupName);

            return group.Roles.Role;
        }

        public List<Change> AllChanges()
        {
            var changeWrapper = _caller.Get<ChangeWrapper>("/app/rest/changes");

            return changeWrapper.Change;
        }

        public Change ChangeDetailsByChangeId(string id)
        {
            var change = _caller.GetFormat<Change>("/app/rest/changes/id:{0}", id);

            return change;
        }

        public List<Change> ChangeDetailsByBuildConfigId(string buildConfigId)
        {
            var changeWrapper = _caller.GetFormat<ChangeWrapper>("/app/rest/changes?buildType={0}", buildConfigId);

            return changeWrapper.Change;
        }

        public Change LastChangeDetailByBuildConfigId(string buildConfigId)
        {
            var changes = ChangeDetailsByBuildConfigId(buildConfigId);

            return changes.FirstOrDefault();
        }

        public List<BuildConfig> AllBuildConfigs()
        {
            var buildType = _caller.Get<BuildTypeWrapper>("/app/rest/buildTypes");

            return buildType.BuildType;
        }

        public BuildConfig BuildConfigByConfigurationName(string buildConfigName)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/name:{0}", buildConfigName);

            return build;
        }

        public void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler)
        {
            _caller.GetDownloadFormat(downloadHandler, "/downloadArtifacts.html?buildId={0}", buildId);
        }

        public BuildConfig BuildConfigByConfigurationId(string buildConfigId)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/id:{0}", buildConfigId);

            return build;
        }

        public BuildConfig BuildConfigByProjectNameAndConfigurationName(string projectName, string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/name:{1}", projectName, buildConfigName));
            return build;
        }

        public BuildConfig BuildConfigByProjectNameAndConfigurationId(string projectName, string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/id:{1}", projectName, buildConfigId));
            return build;
        }

        public BuildConfig BuildConfigByProjectIdAndConfigurationName(string projectId, string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/name:{1}", projectId, buildConfigName));
            return build;
        }

        public BuildConfig BuildConfigByProjectIdAndConfigurationId(string projectId, string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/id:{1}", projectId, buildConfigId));
            return build;
        }

        public List<BuildConfig> BuildConfigsByProjectId(string projectId)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/id:{0}/buildTypes", projectId);

            return buildWrapper.BuildType;
        }

        public List<BuildConfig> BuildConfigsByProjectName(string projectName)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/name:{0}/buildTypes", projectName);

            return buildWrapper.BuildType;
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

        public bool InitialTeamCityInstanceBackup(string fileName)
        {
            var url = string.Format("/app/rest/server/backup?fileName={0}&includeConfigs=true&includeDatabase=true&includeBuildLogs=false", fileName);
            return _caller.StartBackup(url);
        }

        public T CallByUrl<T>(string urlPart)
        {
            var call = _caller.Get<T>(urlPart);
            return call;
        }
    }
}
