# TeamCitySharp

* .NET Library to access TeamCity via their REST API.

Current Stable Version:
[![NuGet version (TeamCitySharp-forked-mavezeau)](https://img.shields.io/nuget/v/TeamCitySharp-forked-mavezeau.svg?style=flat-square)](https://www.nuget.org/packages/TeamCitySharp-forked-mavezeau/)

Latest Version:
[![NuGet version (TeamCitySharp-forked-mavezeau)](https://img.shields.io/nuget/vpre/TeamCitySharp-forked-mavezeau.svg?style=flat-square)](https://www.nuget.org/packages/TeamCitySharp-forked-mavezeau/)

For more information on TeamCity visit:
http://www.jetbrains.com/teamcity

## Releases

Please find the release notes [here](https://github.com/mavezeau/TeamCitySharp/releases)

## License

http://stack72.mit-license.org/

## Installation

There are 2 ways to use TeamCitySharp:

* install-package TeamCitySharp-forked-mavezeau (via Nuget)
* Download source and compile

## Build Monitor

* There is a sample build monitor built with TeamCitySharp. It can be found at [TeamCityMonitor](https://github.com/stack72/TeamCityMonitor)

## Sample Usage

To get a list of projects

    var client = new TeamCityClient("localhost:81");
    client.Connect("admin", "qwerty");
    var projects = client.Projects.All();

To get a list of running builds

    var client = new TeamCityClient("localhost:81");
    client.Connect("admin", "qwerty");
    var builds = client.Builds.ByBuildLocator(BuildLocator.RunningBuilds());

## Connecting to a server

To connect as an authenticated user:

    var client = new TeamCityClient("localhost:81");
    client.Connect("username", "password");

To connect as a Guest:

    var client = new TeamCityClient("localhost:81");
    client.ConnectAsGuest();

To use a previous rest api version:

    var client = new TeamCityClient("localhost:81");
    client.Connect("admin", "qwerty");
    client.UseVersion("7.0"); // 6.0, 7.0, 8.1, 9.0, 9.1, 10.0, 2017.1, 2017.2, 2018.1, latest

Use fields specializations: Extract complex objects for specified Fields

    // For each builds get only the Id, Number, Status and StartDate
    var buildField = BuildField.WithFields(id: true,number:true, status: true, startDate: true);
    var buildsFields = BuildsField.WithFields( buildField: buildField);
    var currentListBuild = client.Builds.GetFields(buildsFields.ToString()).ByBuildConfigId(currentProjectId);

Use fields specializations: Extract statistics from a build with one query

    // For a build get Statistics, id and the build number
    var propertyField = PropertyField.WithFields(name: true, value: true);
    var statisticsField = StatisticsField.WithFields(propertyField: propertyField,href:true, count:true);
    var buildField = BuildField.WithFields(id: true,number:true, statistics: statisticsField);
    var tempBuild = m_client.Builds.LastBuildByBuildConfigId(tempBuildConfig.Id);

## API Interaction Groups

There are many tasks that the TeamCity API can do for us. TeamCitySharp groups these tasks into specialist areas

* Builds
* BuildConfigs
* BuildInvestigations
* BuildQueue
* Projects
* ServerInformation
* Users
* Agents
* VcsRoots
* Changes
* Triggered
* LastChange
* BuildArtifacts
* Statistics

Each area has its own list of methods available

### Builds

    Builds GetFields(string fields);
    List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastSuccessfulBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    List<Build> FailedBuildsByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastFailedBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    List<Build> ErrorBuildsByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastErrorBuildByBuildConfigId(string buildConfigId, List<String> param = null);
    Build LastBuildByAgent(string agentName, List<String> param = null);
    Build ById(string id);
    List<Build> ByBuildConfigId(string buildConfigId);
    List<Build> RunningByBuildConfigId(string buildConfigId);
    List<Build> ByBuildConfigId(string buildConfigId, List<String> param);
    List<Build> ByBuildLocator(BuildLocator locator, List<String> param);
    List<Build> ByConfigIdAndTag(string buildConfigId, string tag);
    List<Build> ByUserName(string userName);
    List<Build> ByBuildLocator(BuildLocator locator);
    List<Build> AllSinceDate(DateTime date, long count = 100, List<string> param = null);
    List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
    List<Build> NonSuccessfulBuildsForUser(string userName);
    List<Build> ByBranch(string branchName);
    void Add2QueueBuildByBuildConfigId(string buildConfigId);
    List<Build> AllRunningBuild();
    List<Build> RetrieveEntireBuildChainFrom(string buildConfigId, bool includeInitial = true, List<string> param = null);
    List<Build> RetrieveEntireBuildChainTo(string buildConfigId, bool includeInitial = true, List<string> param = null);
    List<Build> NextBuilds(string buildid, long count = 100, List<string> param = null);
    List<Build> AffectedProject(string projectId, long count = 100, List<string> param = null);
    void DownloadLogs(string projectId, bool zipped, Action<string> downloadHandler);

### BuildConfigs

    List<BuildConfig> All();
    BuildConfigs GetFields(string fields);
    BuildConfig ByConfigurationName(string buildConfigName);
    BuildConfig ByConfigurationId(string buildConfigId);
    BuildConfig ByProjectNameAndConfigurationName(string projectName, string buildConfigName);
    BuildConfig ByProjectNameAndConfigurationId(string projectName, string buildConfigId);
    BuildConfig ByProjectIdAndConfigurationName(string projectId, string buildConfigName);
    BuildConfig ByProjectIdAndConfigurationId(string projectId, string buildConfigId);
    List<BuildConfig> ByProjectId(string projectId);
    List<BuildConfig> ByProjectName(string projectName);
    bool ModifTrigger(string format, string oldTriggerConfigurationId, string id);
    BuildConfig CreateConfiguration(BuildConfig buildConfig);
    BuildConfig CreateConfiguration(string projectName, string configurationName);
    BuildConfig CreateConfigurationByProjectId(string projectId, string configurationName);
    BuildConfig Copy(string buildConfigId, string buildConfigName, string destinationProjectId, string newBuildTypeId = "");


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
    void SetBuildTypeTemplate(BuildTypeLocator locatorBuildType, BuildTypeLocator locatorTemplate);
    void DeleteSnapshotDependency(BuildTypeLocator locator, string snapshotDependencyId);
    void PostRawSnapshotDependency(BuildTypeLocator locator, XmlElement rawXml);
    BuildConfig BuildType(BuildTypeLocator locator);
    void SetBuildTypeVariable(BuildTypeLocator locatorBuildType, string nameVariable, string value);
    void DeleteConfiguration(BuildTypeLocator locator);
    void DownloadConfiguration(BuildTypeLocator locator, Action<string> downloadHandler);
    Template CopyTemplate(string templateId, string templateName, string destinationProjectId, string newTemplateId = "");
    Template GetTemplate(BuildTypeLocator locator); 
    void AttachTemplate(BuildTypeLocator locator, string templateId);
    void DetachTemplate(BuildTypeLocator locator);
    ArtifactDependencies GetArtifactDependencies(string buildTypeId);
    SnapshotDependencies GetSnapshotDependencies(string buildTypeId);
    bool ModifArtifactDependencies(string format, string oldDendencyConfigurationId, string id);
    bool ModifSnapshotDependencies(string format, string oldDendencyConfigurationId, string id);

    /// <since>8.0</since>
    void DeleteAllBuildTypeParameters(BuildTypeLocator locator);
    void PutAllBuildTypeParameters(BuildTypeLocator locator, IDictionary<string, string> parameters);

    // <since>2017.1</since>
    Branches GetBranchesByBuildConfigurationId(string buildTypeId, BranchLocator locator = null);

    /// <since>2017.2</since>
    Templates GetTemplates(BuildTypeLocator locator); 
    void AttachTemplates(BuildTypeLocator locator, Templates templateList);
    void DetachTemplates(BuildTypeLocator locator);

### BuildInvestigation

    List<Investigation> All();
    BuildInvestigations GetFields(string fields);
    List<Investigation> InvestigationsByBuildTypeId(string buildTypeId);

### BuildQueue

    List<Build> All();
    BuildQueue GetFields(string fields);
    List<Build> ByBuildTypeLocator(BuildTypeLocator locator);
    List<Build> ByProjectLocater(ProjectLocator projectLocator);

### Projects

    List<Project> All();
    Projects GetFields(string fields);
    Project ByName(string projectLocatorName);
    Project ById(string projectLocatorId);
    Project Details(Project project);
    Project Create(string projectName);
    Project Create(string projectName, string sourceId, string projectId = "");
    Project Move(string projectId, string destinationId);
    Project Copy(string projectid, string projectName, string newProjectId, string parentProjectId = "");
    string GenerateID(string projectName);
    void Delete(string projectName);
    void DeleteById(string projectId);
    void DeleteProjectParameter(string projectName, string parameterName);
    void SetProjectParameter(string projectName, string settingName, string settingValue);
    bool ModifParameters(string projectId, string mainprojectbranch, string variablePath);
    bool ModifSettings(string projectId, string description, string fullProjectName);
    ProjectFeatures GetProjectFeatures(string projectLocatorId);
    ProjectFeature GetProjectFeatureByProjectFeature(string projectLocatorId, string projectFeatureId);
    ProjectFeature CreateProjectFeature(string projectId, ProjectFeature projectFeature);
    void DeleteProjectFeature(string projectId, string projectFeatureId);

    // <since>2017.1</since>
    Branches GetBranchesByBuildProjectId(string projectId, BranchLocator locator = null);

### ServerInformation

    Server ServerInfo();
    List<Plugin> AllPlugins();
    string TriggerServerInstanceBackup(BackupOptions backupOptions);
    string GetBackupStatus();

### Users

    List<User> All();
    Users GetFields(string fields);
    User Details(string userName);
    List<Role> AllRolesByUserName(string userName);
    List<Group> AllGroupsByUserName(string userName);
    List<Group> AllUserGroups();
    List<User> AllUsersByUserGroup(string userGroupName);
    List<Role> AllUserRolesByUserGroup(string userGroupName);
    bool Create(string username, string name, string email, string password);
    bool AddPassword(string username, string password);
    bool IsAdministrator(string username);

### Agents

    List<Agent> All(bool includeDisconnected = false, bool includeUnauthorized = false);
    Agents GetFields(string fields);

### VcsRoots

    VcsRoots GetFields(string fields);
    List<VcsRoot> All();
    VcsRoot ById(string vcsRootId);
    VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot);
    void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId);
    void SetVcsRootField(VcsRoot vcsRoot, VcsRootField field, object value);
    VcsRoot CreateVcsRoot(VcsRoot configurationName, string projectId);
    void SetConfigurationProperties(VcsRoot vcsRootId, string key, string value);
    void DeleteProperties(VcsRoot vcsRootId, string parameterName);
    void DeleteVcsRoot(VcsRoot vcsRoot);

### Changes

    List<Change> All();
    Change ByChangeId(string id);
    Change LastChangeDetailByBuildConfigId(string buildConfigId);
    List<Change> ByBuildConfigId(string buildConfigId);

### BuildArtifacts

    void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler);
    ArtifactWrapper ByBuildConfigId(string buildConfigId, string param="");

### Statistics

    Statistics GetFields(string fields);
    Properties GetByBuildId(string buildId);

## Credits

Copyright (c) 2013 Paul Stack (@stack72)

Thanks to the following contributors:

* Barry Mooring (@codingbadger)
* Simon Bartlett (@sibartlett)
* Mike Larah (@MikeLarah)
* Alexander Fast (@mizipzor)
* Serge Baltic
* Philipp Dolder
* Mark deVilliers
* Marc-Andre Vezeau (@exfo)
* Bassem Mawassi (@exfo)
* Tusman Akhter (@exfo)
