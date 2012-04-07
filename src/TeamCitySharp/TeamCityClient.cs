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

        public List<ProjectRef> AllProjects()
        {
            return _caller.Get<ProjectWrapper>("/app/rest/projects").Project;
        }

        public Project ProjectById(string id)
        {
            return _caller.GetFormat<Project>("/app/rest/projects/id:{0}", id);
        }

        public Project ProjectByName(string name)
        {
            return _caller.GetFormat<Project>("/app/rest/projects/name:{0}", name);
        }

        public Server ServerInfo()
        {
            return _caller.Get<Server>("/app/rest/server");
        }

        public List<Plugin> AllServerPlugins()
        {
            return _caller.Get<PluginWrapper>("/app/rest/server/plugins").Plugin;
        }

        public List<Agent> AllAgents()
        {
            return _caller.Get<AgentWrapper>("/app/rest/agents").Agent;
        }

        public List<VcsRoot> AllVcsRoots()
        {
            return _caller.Get<VcsRootWrapper>("/app/rest/vcs-roots").VcsRoot;
        }

        public VcsRoot VcsRootById(string vcsRootId)
        {
            return _caller.GetFormat<VcsRoot>("/app/rest/vcs-roots/id:{0}", vcsRootId);
        }

        public List<User> AllUsers()
        {
            return _caller.Get<UserWrapper>("/app/rest/users").User;
        }

        public User UserByUserName(string userName)
        {
            return _caller.GetFormat<User>("/app/rest/users/username:{0}", userName);
        }

        public List<Group> AllUserGroups()
        {
            return _caller.Get<UserGroupWrapper>("/app/rest/userGroups").Group;
        }

        public Group UserGroupByName(string name)
        {
            return _caller.GetFormat<Group>("/app/rest/userGroups/key:{0}", name);
        }

        public List<Change> AllChanges()
        {
            return _caller.Get<ChangeWrapper>("/app/rest/changes").Change;
        }

        public Change ChangeDetailsByChangeId(string id)
        {
            return _caller.GetFormat<Change>("/app/rest/changes/id:{0}", id);
        }

        public List<Change> ChangeDetailsByBuildConfigId(string buildConfigId)
        {
            return _caller.GetFormat<ChangeWrapper>("/app/rest/changes?buildType={0}", buildConfigId).Change;
        }

        public List<BuildConfig> AllBuildConfigs()
        {
            return _caller.Get<BuildTypeWrapper>("/app/rest/buildTypes").BuildType;
        }

        public BuildConfig BuildConfigById(string id)
        {
            return _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/id:{0}", id);
        }

        public BuildConfig BuildConfigByName(string name)
        {
            return _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/name:{0}", name);
        }

        public BuildConfig BuildConfigByProjectNameAndConfigurationName(string projectName, string buildConfigName)
        {
            return _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/name:{1}", projectName, buildConfigName));
        }

        public BuildConfig BuildConfigByProjectIdAndConfigurationName(string projectId, string buildConfigName)
        {
            return _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/name:{1}", projectId, buildConfigName));
        }

        public List<BuildConfig> BuildConfigsByProjectId(string projectId)
        {
            return _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/id:{0}/buildTypes", projectId).BuildType;
        }

        public List<BuildConfig> BuildConfigsByProjectName(string projectName)
        {
            return _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/name:{0}/buildTypes", projectName).BuildType;
        }
		
		public Build BuildById(long id)
		{
            return _caller.GetFormat<Build>("/app/rest/builds/id:{0}", id);
		}
		
		public Build BuildByNumber(string number)
		{
            return _caller.GetFormat<Build>("/app/rest/builds/number:{0}", number);
		}
		
        public BuildQuery BuildQuery(BuildTypeLocator buildType = null,
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
                                                )
        {
            return new BuildQuery(_caller)
			{
				Locator = BuildLocator.WithDimensions(
					buildType: buildType,
					user: user,
					agentName: agentName,
					status: status,
					personal: personal,
					canceled: canceled,
					running: running,
					pinned: pinned,
					sinceBuild: sinceBuild,
					sinceDate: sinceDate,
					tags: tags)
			};
        }
    }
}
