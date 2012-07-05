#TeamCitySharp

*.NET Library to access TeamCity via their REST API.

For more information on TeamCity visit:
http://www.jetbrains.com/teamcity

##License 
http://stack72.mit-license.org/

##Installation
* install-package TeamCitysharp
* Download source and compile

##Build Monitor
* There is a build monitor build with TeamCitySharp. It can be found at <link>

##Sample Usage
* To get a list of projects

```c#
var client = new TeamCityClient("localhost:81");
client.Connect("admin", "qwerty");
var projects = client.AllProjects();
```


* To get a list of running builds

```c#
var client = new TeamCityClient("localhost:81");
client.Connect("admin", "qwerty");
var builds = client.BuildsByBuildLocator(BuildLocator.RunningBuilds());
```


##Methods Available
```c#
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
```

##Credits

* Copyright (c) 2011 Paul Stack (@stack72)
* Thanks to the following contributors:
* Barry Mooring (@codingbadger)
* Simon Bartlett (@sibartlett)
