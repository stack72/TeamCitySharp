using System.Collections.Generic;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp
{
    public class TeamCityClient : IClientConnection
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




        

        //public List<BuildType> GetAllBuildTypes()
        //{
        //    var buildType = _caller.Get<BuildTypeWrapper>("/httpAuth/app/rest/buildTypes");

        //    return buildType.BuildType;
        //}

        //public BuildType GetBuildTypeByBuildConfigurationName(string buildConfigName)
        //{
        //    var build = _caller.Get<BuildType>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}", buildConfigName));

        //    return build;
        //}

        //public BuildType GetBuildTypeByBuildConfigurationId(string buildConfigId)
        //{
        //    var build = _caller.Get<BuildType>(string.Format("/httpAuth/app/rest/buildTypes/id:{0}", buildConfigId));

        //    return build;
        //}

        //public List<BuildType> GetBuildTypesPerProjectId(string projectId)
        //{
        //    var buildWrapper = _caller.Get<BuildTypeWrapper>(string.Format("/httpAuth/app/rest/projects/id:{0}/buildTypes", projectId));

        //    return buildWrapper.BuildType;
        //}

        //public List<BuildType> GetBuildTypesPerProjectName(string projectName)
        //{
        //    var buildWrapper = _caller.Get<BuildTypeWrapper>(string.Format("/httpAuth/app/rest/projects/name:{0}/buildTypes", projectName));

        //    return buildWrapper.BuildType;
        //}

        //public List<Build> GetSuccessfulBuildsByBuildConfigName(string buildConfigName)
        //{
        //    var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds?status=SUCCESS", buildConfigName));

        //    return buildWrapper.Build;
        //}

        //public Build GetLastSuccessfulBuildByBuildConfigName(string buildConfigName)
        //{
        //    return GetSuccessfulBuildsByBuildConfigName(buildConfigName).FirstOrDefault();
        //}

        //public List<Build> GetCancelledBuildsByBuildConfigName(string buildConfigName)
        //{
        //    var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds?includeCanceled=true", buildConfigName));

        //    return buildWrapper.Build;
        //}

        //public Build GetLastCancelledBuildByBuildConfigName(string buildConfigName)
        //{
        //    return GetCancelledBuildsByBuildConfigName(buildConfigName).FirstOrDefault();
        //}

        //public List<Build> GetFailedBuildsByBuildConfigName(string buildConfigName)
        //{
        //    var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds?status=FAILURE", buildConfigName));

        //    return buildWrapper.Build;
        //}

        //public Build GetLastFailedBuildByBuildConfigName(string buildConfigName)
        //{
        //    return GetFailedBuildsByBuildConfigName(buildConfigName).FirstOrDefault();
        //}

        //public Build GetLastBuildStatusByBuildConfigName(string buildConfigName)
        //{
        //    var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds", buildConfigName));

        //    return buildWrapper.Build.FirstOrDefault();
        //}

        //public List<Build> GetErrorBuildsByBuildConfigName(string buildConfigName)
        //{
        //    var buildWrapper = _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/buildTypes/name:{0}/builds?status=ERROR", buildConfigName));

        //    return buildWrapper.Build;
        //}

        //public Build GetLastErrorBuildByBuildConfigName(string buildConfigName)
        //{
        //    return GetErrorBuildsByBuildConfigName(buildConfigName).FirstOrDefault();
        //}

        //public List<Build> GetBuildsByUserName(string userName)
        //{
        //    var buildWrapper =
        //        _caller.Get<BuildWrapper>(string.Format("/httpAuth/app/rest/builds?locator=user:{0}", userName));

        //    return buildWrapper.Build;
        //}

        //public List<Build> GetNonSuccessfulBuildsForUser(string userName)
        //{
        //    var builds = GetBuildsByUserName(userName);

        //    return builds.Where(b => b.Status != "SUCCESS").ToList();
        //}

    }
}
