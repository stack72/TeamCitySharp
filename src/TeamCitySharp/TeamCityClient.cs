using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

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

        public List<Project> AllProjects()
        {
            var projectWrapper = _caller.Get<ProjectWrapper>("/httpAuth/app/rest/projects");

            return projectWrapper.Project;
        }

        public Project ProjectByName(string projectLocatorName)
        {
            var project = _caller.Get<Project>(string.Format("/httpAuth/app/rest/projects/name:{0}", projectLocatorName));

            return project;
        }

        public Project ProjectById(string projectLocatorId)
        {
            var project = _caller.Get<Project>(string.Format("/httpAuth/app/rest/projects/id:{0}", projectLocatorId));

            return project;
        }

        public Project ProjectDetails(Project project)
        {
            return ProjectById(project.Id);
        }

        public Server ServerInfo()
        {
            var server = _caller.Get<Server>("/httpAuth/app/rest/server");
            return server;
        }

        public List<Plugin> AllServerPlugins()
        {
            var pluginWrapper = _caller.Get<PluginWrapper>("/httpAuth/app/rest/server/plugins");

            return pluginWrapper.Plugin;
        }

        public List<Agent> AllAgents()
        {
            var agentWrapper = _caller.Get<AgentWrapper>("/httpAuth/app/rest/agents");

            return agentWrapper.Agent;
        }

        public Build LastBuildByAgent(string agentName)
        {
            var build = _caller.Get<Build>(string.Format("/httpAuth/app/rest/builds/agentName:{0}", agentName));

            return build;
        }

        public List<VcsRoot> AllVcsRoots()
        {
            var vcsRootWrapper = _caller.Get<VcsRootWrapper>("/httpAuth/app/rest/vcs-roots");

            return vcsRootWrapper.VcsRoot;
        }

        public VcsRoot VcsRootById(string vcsRootId)
        {
            var vcsRoot = _caller.Get<VcsRoot>(string.Format("/httpAuth/app/rest/vcs-roots/id:{0}", vcsRootId));

            return vcsRoot;
        }

        public List<User> AllUsers()
        {
            var userWrapper = _caller.Get<UserWrapper>("/httpAuth/app/rest/users");

            return userWrapper.User;
        }

        public List<Role> AllRolesByUserName(string userName)
        {
            var user =
                _caller.Get<User>(string.Format("/httpAuth/app/rest/users/username:{0}", userName));

            return user.Roles.Role;
        }

        public List<Group> AllGroupsByUserName(string userName)
        {
            var user =
                _caller.Get<User>(string.Format("/httpAuth/app/rest/users/username:{0}", userName));

            return user.Groups.Group;
        }

        public List<Group> AllUserGroups()
        {
            var userGroupWrapper = _caller.Get<UserGroupWrapper>("/httpAuth/app/rest/userGroups");

            return userGroupWrapper.Group;
        }

        public List<User> AllUsersByUserGroup(string userGroupName)
        {
            var group = _caller.Get<Group>(string.Format("/httpAuth/app/rest/userGroups/key:{0}", userGroupName));

            return group.Users.User;
        }

        public List<Role> AllUserRolesByUserGroup(string userGroupName)
        {
            var group = _caller.Get<Group>(string.Format("/httpAuth/app/rest/userGroups/key:{0}", userGroupName));

            return group.Roles.Role;
        }

        public List<Change> AllChanges()
        {
            var changeWrapper = _caller.Get<ChangeWrapper>("/httpAuth/app/rest/changes");

            return changeWrapper.Change;
        }

        public Change ChangeDetailsByChangeId(string id)
        {
            var change = _caller.Get<Change>(string.Format("/httpAuth/app/rest/changes/id:{0}", id));

            return change;
        }

        public List<BuildConfig> AllBuildConfigs()
        {
            var buildType = _caller.Get<BuildTypeWrapper>("/httpAuth/app/rest/buildTypes");

            return buildType.BuildType;
        }

        public BuildConfig BuildConfigByConfigurationName(string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}", buildConfigName));

            return build;
        }

        public BuildConfig BuildConfigByConfigurationId(string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}", buildConfigId));

            return build;
        }

        public List<BuildConfig> BuildConfigsByProjectId(string projectId)
        {
            var buildWrapper = _caller.Get<BuildTypeWrapper>(string.Format("/httpAuth/app/rest/projects/id:{0}/buildTypes", projectId));

            return buildWrapper.BuildType;
        }

        public List<BuildConfig> BuildConfigsByProjectName(string projectName)
        {
            var buildWrapper = _caller.Get<BuildTypeWrapper>(string.Format("/httpAuth/app/rest/projects/name:{0}/buildTypes", projectName));

            return buildWrapper.BuildType;
        }

        public List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}/builds?status=SUCCESS", buildConfigId));

            return buildWrapper.Build;
        }

        public Build LastSuccessfulBuildByBuildConfigId(string buildConfigId)
        {
            return SuccessfulBuildsByBuildConfigId(buildConfigId).FirstOrDefault();
        }

        public List<Build> FailedBuildsByBuildConfigId(string buildConfigId)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}/builds?status=FAILURE", buildConfigId));

            return buildWrapper.Build;
        }

        public Build LastFailedBuildByBuildConfigId(string buildConfigId)
        {
            return FailedBuildsByBuildConfigId(buildConfigId).FirstOrDefault();
        }

        public Build LastBuildByBuildConfigId(string buildConfigId)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}/builds", buildConfigId));

            return buildWrapper.Build.FirstOrDefault();
        }

        public List<Build> ErrorBuildsByBuildConfigId(string buildConfigId)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}/builds?status=ERROR", buildConfigId));

            return buildWrapper.Build;
        }

        public Build LastErrorBuildByBuildConfigId(string buildConfigId)
        {
            return ErrorBuildsByBuildConfigId(buildConfigId).FirstOrDefault();
        }

        public List<Build> BuildConfigsByBuildConfigId(string buildConfigId)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}/builds", buildConfigId));

            return buildWrapper.Build;
        }

        public List<Build> BuildConfigsByConfigIdAndTag(string buildConfigId, string tag)
        {
            var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}/builds?tag={1}", buildConfigId, tag));

            return buildWrapper.Build;
        }

        public List<Build> BuildsByUserName(string userName)
        {
            return BuildsByBuildLocator(BuildLocator.WithDimensions(user: UserLocator.WithUserName(userName)));
        }

        public List<Build> BuildsByBuildLocator(BuildLocator locator)
        {
            var buildWrapper =
                _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/builds?locator={0}", locator));

            return buildWrapper.Build;
        }

        public List<Build> NonSuccessfulBuildsForUser(string userName)
        {
            var builds = BuildsByUserName(userName);

            return builds.Where(b => b.Status != "SUCCESS").ToList();
        }
    }
}
