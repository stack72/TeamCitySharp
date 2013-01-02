using TeamCitySharp.ActionTypes;

namespace TeamCitySharp
{
    public interface ITeamCityClient
    {
        void Connect(string userName, string password, bool actAsGuest = false);
        bool Authenticate();

        IBuilds Builds { get; }
        IBuildConfigs BuildConfigs { get; }
        IProjects Projects { get; }
        IServerInformation ServerInformation { get; }
        IUsers Users { get; }
        IAgents Agents { get; }
        IVcsRoots VcsRoots { get; }
        IChanges Changes { get; }

        #region still to move to new structure

        //bool TriggerServerInstanceBackup(string fileName);

        //T CallByUrl<T>(string urlPart);

        //BuildConfig CreateConfiguration(string projectName, string configurationName);
        //void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue);
        //VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot);
        //void SetVcsRootField(VcsRoot vcsRoot, VcsRootField field, object value);
        //void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml);
        //void PostRawBuildStep(BuildTypeLocator locator, string rawXml);
        //void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml);
        //void SetProjectParameter(string projectName, string settingName, string settingValue);
        //void SetConfigurationParameter(BuildTypeLocator locator, string key, string value);
        //void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml);
        //void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId);
        //void DeleteBuildStep(BuildTypeLocator locator, string buildStepId);
        //void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId);
        //void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId);
        //void DeleteParameter(BuildTypeLocator locator, string parameterName);

        //void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId);

        #endregion
    }
}