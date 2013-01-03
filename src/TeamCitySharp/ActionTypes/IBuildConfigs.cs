using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuildConfigs
    {
        List<BuildConfig> All();
        BuildConfig ByConfigurationName(string buildConfigName);
        BuildConfig ByConfigurationId(string buildConfigId);
        BuildConfig ByProjectNameAndConfigurationName(string projectName, string buildConfigName);
        BuildConfig ByProjectNameAndConfigurationId(string projectName, string buildConfigId);
        BuildConfig ByProjectIdAndConfigurationName(string projectId, string buildConfigName);
        BuildConfig ByProjectIdAndConfigurationId(string projectId, string buildConfigId);
        List<BuildConfig> ByProjectId(string projectId);
        List<BuildConfig> ByProjectName(string projectName);
        BuildConfig CreateConfiguration(string projectName, string configurationName);

        void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue);
        void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml);
        void PostRawBuildStep(BuildTypeLocator locator, string rawXml);
        void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml);
        void SetConfigurationParameter(BuildTypeLocator locator, string key, string value);
        void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml);
        void DeleteBuildStep(BuildTypeLocator locator, string buildStepId);
        void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId);
        void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId);
        void DeleteParameter(BuildTypeLocator locator, string parameterName);
        void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId);
    }
}