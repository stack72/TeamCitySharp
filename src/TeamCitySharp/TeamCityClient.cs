using System;
using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp
{
    public class TeamCityClient : IClientConnection, ITeamCityClient
    {
        private readonly TeamCityCaller _caller;
        private IBuilds _builds;
        private IProjects _projects;
        private IBuildConfigs _buildConfigs;
        private IServerInformation _serverInformation;
        private IUsers _users;
        private IAgents _agents;
        private IVcsRoots _vcsRoots;
        private IChanges _changes;

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

        public IBuilds Builds
        {
            get { return _builds ?? (_builds = new Builds(_caller)); }
        }

        public IBuildConfigs BuildConfigs
        {
            get { return _buildConfigs ?? (_buildConfigs = new BuildConfigs(_caller)); }
        }

        public IProjects Projects
        {
            get { return _projects ?? (_projects = new Projects(_caller)); }
        }

        public IServerInformation ServerInformation
        {
            get { return _serverInformation ?? (_serverInformation = new ServerInformation(_caller)); }
        }

        public IUsers Users
        {
            get { return _users ?? (_users = new Users(_caller)); }
        }

        public IAgents Agents
        {
            get { return _agents ?? (_agents = new Agents(_caller)); }
        }

        public IVcsRoots VcsRoots
        {
            get { return _vcsRoots ?? (_vcsRoots = new VcsRoots(_caller)); }
        }

        public IChanges Changes
        {
            get { return _changes ?? (_changes = new Changes(_caller)); }
        }

        #region old code
        
        



        
        public void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler)
        {
            _caller.GetDownloadFormat(downloadHandler, "/downloadArtifacts.html?buildId={0}", buildId);
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



        public void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/triggers/{1}", locator, buildTriggerId);
        }

        private string ToCamelCase(string s)
        {
            return Char.ToLower(s.ToCharArray()[0]) + s.Substring(1);
        }


        public bool TriggerServerInstanceBackup(string fileName)
        {
            var url = string.Format("/app/rest/server/backup?fileName={0}&includeConfigs=true&includeDatabase=true&includeBuildLogs=false", fileName);
            return _caller.StartBackup(url);
        }


        public T CallByUrl<T>(string urlPart)
        {
            var call = _caller.Get<T>(urlPart);
            return call;
        }
        #endregion
    }
}