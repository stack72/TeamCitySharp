using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp
{
    public interface ITeamCityClient
    {
        void Connect(string userName, string password, bool actAsGuest = false);
        List<Project> AllProjects();
        Project ProjectByName(string projectLocatorName);
        Project ProjectById(string projectLocatorId);
        Project ProjectDetails(Project project);
        Server ServerInfo();
        List<Plugin> AllServerPlugins();
        List<Agent> AllAgents();
        Build LastBuildByAgent(string agentName);
        List<VcsRoot> AllVcsRoots();
        VcsRoot VcsRootById(string vcsRootId);
        List<User> AllUsers();
        List<Role> AllRolesByUserName(string userName);
        List<Group> AllGroupsByUserName(string userName);
        List<Group> AllUserGroups();
        List<User> AllUsersByUserGroup(string userGroupName);
        List<Role> AllUserRolesByUserGroup(string userGroupName);
        List<Change> AllChanges();
        Change ChangeDetailsByChangeId(string id);
        List<BuildConfig> AllBuildConfigs();
        BuildConfig BuildConfigByConfigurationName(string buildConfigName);
        BuildConfig BuildConfigByConfigurationId(string buildConfigId);
        BuildConfig BuildConfigByProjectNameAndConfigurationName(string projectName, string buildConfigName);
        BuildConfig BuildConfigByProjectNameAndConfigurationId(string projectName, string buildConfigId);
        BuildConfig BuildConfigByProjectIdAndConfigurationName(string projectId, string buildConfigName);
        BuildConfig BuildConfigByProjectIdAndConfigurationId(string projectId, string buildConfigId);
        List<BuildConfig> BuildConfigsByProjectId(string projectId);
        List<BuildConfig> BuildConfigsByProjectName(string projectName);
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
        List<Build> NonSuccessfulBuildsForUser(string userName);
    }
}