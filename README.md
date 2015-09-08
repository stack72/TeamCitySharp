#TeamCitySharp fork by @borismod

* Fork of Paul Slack's original .NET Library to access TeamCity via their REST API. This fork has some additional features, bug fixes and breaking changes. Tested on TeamCity 8.0.5 and 9.1

For more information on TeamCity visit:
[TeamCity REST API v9](https://confluence.jetbrains.com/display/TCD9/REST+API)

##License 
http://stack72.mit-license.org/

##Installation
Currently there is one way of using TeamCitySharp:

* Download source and compile

##Sample Usage
To get a list of projects

    var client = new TeamCityClient("localhost:81");
    client.Connect("admin", "qwerty");
    var projects = client.Projects.All();


To get a list of running builds

    var client = new TeamCityClient("localhost:81");
    client.Connect("admin", "qwerty");
    var builds = client.Builds.ByBuildLocator(BuildLocator.RunningBuilds());

##Connecting to a server

To connect as an authenticated user:

    var client = new TeamCityClient("localhost:81");
    client.Connect("username", "password");

To connect as a Guest:

    var client = new TeamCityClient("localhost:81");
    client.ConnectAsGuest();
    
##API Interaction Groups
There are many tasks that the TeamCity API can do for us. TeamCitySharp groups these tasks into specialist areas

* Builds
* Projects
* BuildConfigs
* ServerInformation
* Users
* Agents
* VcsRoots
* Changes
* BuildArtifacts
* TestOccurrences

Each area has its own list of methods available

###Builds
    List<Build> SuccessfulBuildsByBuildConfigId(string buildConfigId);
	Build LastSuccessfulBuildByBuildConfigId(string buildConfigId);
	List<Build> FailedBuildsByBuildConfigId(string buildConfigId);
	Build LastFailedBuildByBuildConfigId(string buildConfigId);
	Build LastBuildByBuildConfigId(string buildConfigId);
	List<Build> ErrorBuildsByBuildConfigId(string buildConfigId);
	Build LastErrorBuildByBuildConfigId(string buildConfigId);
	List<Build> ByBuildConfigId(string buildConfigId);
	List<Build> ByConfigIdAndTag(string buildConfigId, string tag);
	List<Build> ByUserName(string userName);
	List<Build> ByBuildLocator(BuildLocator locator);
	List<Build> AllSinceDate(DateTime date);
	List<Build> AllBuildsOfStatusSinceDate(DateTime date, BuildStatus buildStatus);
	List<Build> NonSuccessfulBuildsForUser(string userName);
	Build LastBuildByAgent(string agentName);

###Projects
	List<Project> All();
	Project ByName(string projectLocatorName);
	Project ById(string projectLocatorId);
	Project Details(Project project);
	Project Create(string projectName);
	void Delete(string projectName);
	void DeleteProjectParameter(string projectName, string parameterName);
	void SetProjectParameter(string projectName, string settingName, string settingValue);

###BuildConfigs
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

	void SetBuildTypeTemplate(BuildTypeLocator locatorBuildType, BuildTypeLocator locatorTemplate);
	void DeleteSnapshotDependency(BuildTypeLocator locator, string snapshotDependencyId);
	void PostRawSnapshotDependency(BuildTypeLocator locator, XmlElement rawXml);
	BuildConfig BuildType(BuildTypeLocator locator);

    void DeleteConfiguration(BuildTypeLocator locator);
    void DeleteAllBuildTypeParameters(BuildTypeLocator locator);
    void PutAllBuildTypeParameters(BuildTypeLocator locator, IDictionary<string, string> parameters);
    void DownloadConfiguration(BuildTypeLocator locator, Action<string> downloadHandler);
    
    void TriggerBuildConfiguration(string buildConfigId)
    void TriggerBuildConfiguration(string buildConfigId, Property[] properties);
    void TriggerBuildConfiguration(string buildConfigId, int agentId, Property[] properties)
    
    void UpdateName(BuildtypeLocator buildTypeLocator, string newName);

###ServerInformation
    Server ServerInfo();
    List<Plugin> AllPlugins();
    string TriggerServerInstanceBackup(BackupOptions backupOptions);

###Users
    List<User> All();
    User Details(string userName);
    List<Role> AllRolesByUserName(string userName);
    List<Group> AllGroupsByUserName(string userName);
    List<Group> AllUserGroups();
    List<User> AllUsersByUserGroup(string userGroupName);
    List<Role> AllUserRolesByUserGroup(string userGroupName);
    bool Create(string username, string name, string email, string password);
    bool AddPassword(string username, string password);

###Agents
    List<Agent> All();

###VcsRoots
    List<VcsRoot> All();
    VcsRoot ById(string vcsRootId);
    VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot);
    void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId);
    void SetVcsRootField(VcsRoot vcsRoot, VcsRootField field, object value);

###Changes
    List<Change> All();
    Change ByChangeId(string id);
    Change LastChangeDetailByBuildConfigId(string buildConfigId);
    List<Change> ByBuildConfigId(string buildConfigId);
    
    // Return list of changes with basic information
    List<Change> ByBuildId(long buildId);
    
    /// Returns list of changes with their details
    List<Change> ByBuildIdWithDetails(long buildId);

###BuildArtifacts
    void DownloadArtifactsByBuildId(string buildId, Action<string> downloadHandler);

###TestOccurrences
    List<TestOccurrence> TestOccurrencesByBuildId(long buildId, int? indexStart = 0, int? maxResults = 100);
    List<TestOccurrence> FailedTestOccurrencesByBuildId(long buildId, int? indexStart = 0, int? maxResults = 100);
    
    /// Retrieves an instance of TestOccurence by Id as received from TeamCity API 
    TestOccurrence TestOccurrenceById(string testOccurenceLocator);
    
##Credits

Copyright (c) 2013 Paul Stack (@stack72)

Thanks to the following contributors:

* Barry Mooring (@codingbadger)
* Simon Bartlett (@sibartlett)
* Mike Larah (@MikeLarah)
* Alexander Fast (@mizipzor)
* Serge Baltic
* Philipp Dolder
* Mark deVilliers
