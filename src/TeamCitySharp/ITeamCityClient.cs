using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp
{
    public interface ITeamCityClient
    {
        void Connect(string userName, string password, bool actAsGuest = false);
        
		Server ServerInfo();
        List<Plugin> AllServerPlugins();
        List<Agent> AllAgents();
		
        List<ProjectRef> AllProjects();
        Project ProjectById(string projectLocatorId);
        Project ProjectByName(string projectLocatorName);
        
		List<VcsRoot> AllVcsRoots();
        VcsRoot VcsRootById(string vcsRootId);
        
		List<User> AllUsers();
		User UserByUserName(string userName);
        
		List<Group> AllUserGroups();
		Group UserGroupByName(string userGroupName);
		
        List<Change> AllChanges();
        Change ChangeDetailsByChangeId(string id);
        List<Change> ChangeDetailsByBuildConfigId(string buildConfigId);
		
        List<BuildConfig> AllBuildConfigs();
        BuildConfig BuildConfigById(string id);
        BuildConfig BuildConfigByName(string name);
        BuildConfig BuildConfigByProjectIdAndConfigurationName(string projectId, string buildConfigName);
        BuildConfig BuildConfigByProjectNameAndConfigurationName(string projectName, string buildConfigName);
        List<BuildConfig> BuildConfigsByProjectId(string projectId);
        List<BuildConfig> BuildConfigsByProjectName(string projectName);
		
		Build BuildById(long id);
		Build BuildByNumber(string number);
        BuildQuery BuildQuery(
			BuildTypeLocator buildType = null,
	        UserLocator user = null,
	        string agentName = null,
	        BuildStatus? status = null,
	        bool? personal = null,
	        bool? canceled = null,
	        bool? running = null,
	        bool? pinned = null,
	        BuildLocator sinceBuild = null,
	        DateTime? sinceDate = null,
	        string[] tags = null
	    );
    }
}