using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.XPath;
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

        public void DownloadArtifact(string url, Action<string> downloadHandler)
        {
            _caller.GetDownloadFormat(downloadHandler, url);
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

            if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
            return buildWrapper.BuildType;
        }

        public List<BuildConfig> BuildConfigsByProjectName(string projectName)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/name:{0}/buildTypes", projectName);

            if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
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

        public Project CreateProject(string projectName)
        {
            return _caller.Post<Project>(projectName, "/app/rest/projects/");
        }

        public void DeleteProject(string projectName)
        {
            _caller.DeleteFormat("/app/rest/projects/name:{0}", projectName);
        }

        public BuildConfig CreateConfiguration(string projectName, string configurationName)
        {
            return _caller.PostFormat<BuildConfig>(configurationName, "/app/rest/projects/name:{0}/buildTypes", projectName);
        }

        public void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue)
        {
            _caller.PutFormat(settingValue, "/app/rest/buildTypes/{0}/settings/{1}", locator, settingName);
        }

        public VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot)
        {
            string xml = string.Format(@"<vcs-root-entry><vcs-root id=""{0}""/></vcs-root-entry>", vcsRoot.Id);
            return _caller.PostFormat<VcsRoot>(xml, "/app/rest/buildTypes/{0}/vcs-root-entries", locator);
        }

        public void SetVcsRootField(VcsRoot vcsRoot, VcsRootField field, object value)
        {
            _caller.PutFormat(value, "/app/rest/vcs-roots/id:{0}/{1}", vcsRoot.Id, ToCamelCase(field.ToString()));
        }

        public void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat<ArtifactDependency>(rawXml, "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
        }

        public void PostRawBuildStep(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat<BuildConfig>(rawXml, "/app/rest/buildTypes/{0}/steps", locator);
        }

        public void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat(rawXml, "/app/rest/buildTypes/{0}/triggers", locator);
        }

        public void SetProjectParameter(string projectName, string settingName, string settingValue)
        {
            _caller.PutFormat(settingValue, "/app/rest/projects/name:{0}/parameters/{1}", projectName, settingName);
        }

        public void SetConfigurationParameter(BuildTypeLocator locator, string key, string value)
        {
            _caller.PutFormat(value, "/app/rest/buildTypes/{0}/parameters/{1}", locator, key);
        }

        public void DeleteConfiguration(BuildTypeLocator locator)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}", locator);
        }

        public void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat(rawXml, "/app/rest/buildTypes/{0}/agent-requirements", locator);
        }

        public void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/vcs-root-entries/{1}", locator, vcsRootId);
        }

        public void DeleteBuildStep(BuildTypeLocator locator, string buildStepId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/steps/{1}", locator, buildStepId);
        }

        public void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/artifact-dependencies/{1}", locator, artifactDependencyId);
        }

        public void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/agent-requirements/{1}", locator, agentRequirementId);
        }

        public void DeleteParameter(BuildTypeLocator locator, string parameterName)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/parameters/{1}", locator, parameterName);
        }

        public void DeleteProjectParameter(string projectName, string parameterName)
        {
            _caller.DeleteFormat("/app/rest/projects/name:{0}/parameters/{1}", projectName, parameterName);
        }

        public void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/triggers/{1}", locator, buildTriggerId);
        }

        private string ToCamelCase(string s)
        {
            return Char.ToLower(s.ToCharArray()[0]) + s.Substring(1);
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

        public List<string> ArtifactsByBuildConfigIdLastFinished(string buildConfigId)
        {
            return ArtifactsByBuildConfigIdAndBuildNumber(buildConfigId, ".lastFinished");
        }

        public List<string> ArtifactsByBuildConfigIdLastPinned(string buildConfigId)
        {
            return ArtifactsByBuildConfigIdAndBuildNumber(buildConfigId, ".lastPinned");
        }

        public List<string> ArtifactsByBuildConfigIdLastSuccessful(string buildConfigId)
        {
            return ArtifactsByBuildConfigIdAndBuildNumber(buildConfigId, ".lastSuccessful");
        }

        public List<string> ArtifactsByBuildConfigIdAndTag(string buildConfigId, string tag)
        {
            return ArtifactsByBuildConfigIdAndBuildNumber(buildConfigId, tag + ".tcbuildtag");
        }

        public List<string> ArtifactsByBuildConfigIdAndBuildNumber(string buildConfigId, string buildSpecification)
        {
            var xml = _caller.GetRaw(string.Format("/repository/download/{0}/{1}/teamcity-ivy.xml", buildConfigId, buildSpecification));

            var document = new XmlDocument();
            document.LoadXml(xml);
            var artifactNodes = document.SelectNodes("//artifact");
            if (artifactNodes == null)
            {
                return null;
            }
            var list = new List<string>();
            foreach (XmlNode node in artifactNodes)
            {
                var nameNode = node.SelectSingleNode("@name");
                var extensionNode = node.SelectSingleNode("@ext");
                var artifact = string.Empty;
                if (nameNode != null)
                {
                    artifact = nameNode.Value;
                }
                if (extensionNode != null)
                {
                    artifact += "." + extensionNode.Value;
                }
                list.Add(string.Format("/repository/download/{0}/{1}/{2}", buildConfigId, buildSpecification, artifact));
            }
            return list;
        }

        public bool TriggerServerInstanceBackup(string fileName)
        {
            var url = string.Format("/app/rest/server/backup?fileName={0}&includeConfigs=true&includeDatabase=true&includeBuildLogs=false", fileName);
            return _caller.StartBackup(url);
        }

        public bool CreateUser(string username, string name, string email, string password)
        {
            bool result = false;

            string data = string.Format("<user name=\"{0}\" username=\"{1}\" email=\"{2}\" password=\"{3}\"/>", name, username, email, password);

            var createUserResponse = this._caller.Post("/app/rest/users", data, string.Empty);

            // Workaround, CreateUser POST request fails to deserialize password field. See http://youtrack.jetbrains.com/issue/TW-23200
            // Also this does not return an accurate representation of whether it has worked or not
            bool passwordResult = AddPassword(username, password);

            if (createUserResponse.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }

            return result;
        }

        public bool AddPassword(string username, string password)
        {
            bool result = false;

            var response = this._caller.Put(string.Format("/app/rest/users/username:{0}/password", username), password, string.Empty);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result = true;
            }

            return result;
        }

        public T CallByUrl<T>(string urlPart)
        {
            var call = _caller.Get<T>(urlPart);
            return call;
        }
    }
}
