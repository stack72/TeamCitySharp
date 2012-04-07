using System;
using System.Collections.Generic;
using System.Linq;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp
{
	public static class TeamCityClientExtensions
	{
		public static List<BuildRef> RunningBuilds(this ITeamCityClient client)
		{
			return client.BuildQuery(running:true).List();	
		}

        public static Build LastBuildByAgent(this ITeamCityClient client, string agentName)
        {
			return client.BuildQuery(agentName: agentName).Latest();
        }

        public static List<BuildRef> SuccessfulBuildsByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
			return client.BuildQuery(
				status: BuildStatus.SUCCESS,
				buildType: BuildTypeLocator.WithId(buildConfigId)
			).List();
        }

        public static Build LastSuccessfulBuildByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
            return client.BuildQuery(
                status: BuildStatus.SUCCESS,
				buildType: BuildTypeLocator.WithId(buildConfigId)
            ).Latest();
        }

        public static List<BuildRef> FailedBuildsByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
			return client.BuildQuery(
				status: BuildStatus.FAILURE,
				buildType: BuildTypeLocator.WithId(buildConfigId)
			).List();
        }

        public static Build LastFailedBuildByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
            return client.BuildQuery(
                status: BuildStatus.FAILURE,
				buildType: BuildTypeLocator.WithId(buildConfigId)
            ).Latest();
        }

        public static Build LastBuildByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
            return client.BuildQuery(
				buildType: BuildTypeLocator.WithId(buildConfigId)
            ).Latest();
        }

        public static List<BuildRef> ErrorBuildsByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
			return client.BuildQuery(
				status: BuildStatus.ERROR,
				buildType: BuildTypeLocator.WithId(buildConfigId)
			).List();
        }

        public static Build LastErrorBuildByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
            return client.BuildQuery(
                status: BuildStatus.ERROR,
				buildType: BuildTypeLocator.WithId(buildConfigId)
            ).Latest();
        }

        public static List<BuildRef> BuildConfigsByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
			return client.BuildQuery(
				buildType: BuildTypeLocator.WithId(buildConfigId)
			).List();
        }

        public static List<BuildRef> BuildConfigsByConfigIdAndTags(this ITeamCityClient client, string buildConfigId, params string[] tags)
        {
			return client.BuildQuery(
				buildType: BuildTypeLocator.WithId(buildConfigId),
				tags: tags
			).List();
        }

        public static List<BuildRef> BuildsByUserName(this ITeamCityClient client, string userName)
        {
			return client.BuildQuery(
				user: UserLocator.WithUserName(userName)
			).List();
        }

        public static List<BuildRef> AllBuildsSinceDate(this ITeamCityClient client, DateTime date)
        {
			return client.BuildQuery(sinceDate: date).List();
        }

        public static List<BuildRef> AllBuildsOfStatusSinceDate(this ITeamCityClient client, DateTime date, BuildStatus buildStatus)
        {
            return client.BuildQuery(sinceDate: date, status: buildStatus).List();
        }

        public static List<BuildRef> NonSuccessfulBuildsForUser(this ITeamCityClient client, string userName)
        {
            return client.BuildsByUserName(userName).Where(b => b.Status != "SUCCESS").ToList();
        }

        public static Project ProjectDetails(this ITeamCityClient client, ProjectRef project)
        {
            return client.ProjectById(project.Id);
        }
		
        public static Change LastChangeDetailByBuildConfigId(this ITeamCityClient client, string buildConfigId)
        {
            return client.ChangeDetailsByBuildConfigId(buildConfigId).FirstOrDefault();
        }

        public static List<Role> AllRolesByUserName(this ITeamCityClient client, string userName)
        {
            var user = client.UserByUserName(userName);
            return user.Roles == null ? new List<Role>() : user.Roles.Role;
        }

        public static List<Group> AllGroupsByUserName(this ITeamCityClient client, string userName)
        {
            var user = client.UserByUserName(userName);
            return user.Groups == null ? new List<Group>() : user.Groups.Group;
        }

        public static List<User> AllUsersByUserGroup(this ITeamCityClient client, string userGroupName)
        {
            var group = client.UserGroupByName(userGroupName);
            return group.Users == null ? new List<User>() : group.Users.User;
        }

        public static List<Role> AllUserRolesByUserGroup(this ITeamCityClient client, string userGroupName)
        {
            var group = client.UserGroupByName(userGroupName);
            return group.Users == null ? new List<Role>() : group.Roles.Role;
        }
	}
}
