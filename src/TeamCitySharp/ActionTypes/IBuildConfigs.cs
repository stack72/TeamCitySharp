using System;
using System.Collections.Generic;
using System.Xml;
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
        bool GetConfigurationPauseStatus(BuildTypeLocator locator);
        void SetConfigurationPauseStatus(BuildTypeLocator locator, bool isPaused);
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

        /// <summary>
        /// Makes a build type inherit a template.
        /// </summary>
        /// <param name="locatorBuildType">Locator for the build type which is to be associated with a template.</param>
        /// <param name="locatorTemplate">Locator for the template.</param>
        void SetBuildTypeTemplate(BuildTypeLocator locatorBuildType, BuildTypeLocator locatorTemplate);

        /// <summary>
        /// Deletes a snapshot dependency from a build type.
        /// </summary>
        /// <param name="locator">Locator for the build type.</param>
        /// <param name="snapshotDependencyId">The <see cref="SnapshotDependency.Id"/> field value of the dependency to be removed.</param>
        void DeleteSnapshotDependency(BuildTypeLocator locator, string snapshotDependencyId);

        /// <summary>
        /// <para>Adds a snapshot dependency to a build type. Have to post raw XML data which looks like this:</para>
        /// <code><![CDATA[
        /// <snapshot-dependency type="snapshot_dependency">
        ///        <properties>
        ///            <property name="source_buildTypeId" value="id-of-the-target-build-type"/>
        ///            <property name="run-build-if-dependency-failed" value="true"/>
        ///            <property name="run-build-on-the-same-agent" value="false"/>
        ///            <property name="take-started-build-with-same-revisions" value="true"/>
        ///            <property name="take-successful-builds-only" value="true"/>
        ///        </properties>
        ///    </snapshot-dependency>
        /// ]]></code>
        /// </summary>
        void PostRawSnapshotDependency(BuildTypeLocator locator, XmlElement rawXml);

        /// <summary>
        /// <para>Locates a build type by its locator.</para>
        /// <para>Essentially, it works either like <see cref="BuildConfigByConfigurationId"/> or <see cref="BuildConfigByConfigurationName"/>, whichever is defined in the locator.</para>
        /// </summary>
        /// <param name="locator">Locator for the build type.</param>
        /// <returns>The build type with all its properties.</returns>
        BuildConfig BuildType(BuildTypeLocator locator);

        void DeleteConfiguration(BuildTypeLocator locator);

        /// <summary>
        /// Deletes all of the parameters defined locally on this build type.
        /// This spares those parameters inherited from the template, you will still get them when listing all parameters.
        /// </summary>
        /// <since>8.0</since>
        void DeleteAllBuildTypeParameters(BuildTypeLocator locator);

        /// <summary>
        /// Replaces all of the parameters defined locally on this build type with the new set supplied.
        /// Same as calling <see cref="DeleteAllBuildTypeParameters"/> and then <see cref="SetConfigurationParameter"/> for each entry.
        /// </summary>
        /// <since>8.0</since>
        void PutAllBuildTypeParameters(BuildTypeLocator locator, IDictionary<string, string> parameters);

        void DownloadConfiguration(BuildTypeLocator locator, Action<string> downloadHandler);
    }
}