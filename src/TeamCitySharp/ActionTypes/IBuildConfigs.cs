using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    public interface IBuildConfigs
    {
        List<BuildConfig> AllBuildConfigs();
        BuildConfig BuildConfigByConfigurationName(string buildConfigName);
        BuildConfig BuildConfigByConfigurationId(string buildConfigId);
        BuildConfig BuildConfigByProjectNameAndConfigurationName(string projectName, string buildConfigName);
        BuildConfig BuildConfigByProjectNameAndConfigurationId(string projectName, string buildConfigId);
        BuildConfig BuildConfigByProjectIdAndConfigurationName(string projectId, string buildConfigName);
        BuildConfig BuildConfigByProjectIdAndConfigurationId(string projectId, string buildConfigId);
        List<BuildConfig> BuildConfigsByProjectId(string projectId);
        List<BuildConfig> BuildConfigsByProjectName(string projectName);
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