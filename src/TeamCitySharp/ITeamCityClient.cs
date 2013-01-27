using System;
using System.Collections.Generic;
using System.Xml;

using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp
{
    public interface ITeamCityClient
    {
        void Connect(string userName, string password, bool actAsGuest = false);
        bool Authenticate();
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
        Change LastChangeDetailByBuildConfigId(string buildConfigId);
        List<Change> ChangeDetailsByBuildConfigId(string buildConfigId);
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
        List<Build> AllBuildsSinceDate(DateTime date);
        List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
        List<Build> NonSuccessfulBuildsForUser(string userName);
        bool TriggerServerInstanceBackup(string fileName);
        bool CreateUser(string username, string name, string email, string password);
        bool AddPassword(string username, string password);

        T CallByUrl<T>(string urlPart);

        Project CreateProject(string projectName);
        void DeleteProject(string projectName);
        BuildConfig CreateConfiguration(string projectName, string configurationName);
        void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue);
        VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot);
        void SetVcsRootField(VcsRoot vcsRoot, VcsRootField field, object value);
        void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml);
        void PostRawBuildStep(BuildTypeLocator locator, string rawXml);
        void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml);
        void SetProjectParameter(string projectName, string settingName, string settingValue);
        void SetConfigurationParameter(BuildTypeLocator locator, string key, string value);
        void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml);
        void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId);
        void DeleteBuildStep(BuildTypeLocator locator, string buildStepId);
        void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId);
        void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId);
        void DeleteParameter(BuildTypeLocator locator, string parameterName);
        void DeleteProjectParameter(string projectName, string parameterName);
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
        /// <para>Locates a build type by its locator.</para>
        /// <para>Essentially, it works either like <see cref="BuildConfigByConfigurationId"/> or <see cref="BuildConfigByConfigurationName"/>, whichever is defined in the locator.</para>
        /// </summary>
        /// <param name="locator">Locator for the build type.</param>
        /// <returns>The build type with all its properties.</returns>
        BuildConfig BuildType(BuildTypeLocator locator);

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
    }
}