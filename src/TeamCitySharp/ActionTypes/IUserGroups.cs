namespace TeamCitySharp.ActionTypes
{
    public interface IUserGroups
    {
        bool AddGroup(string groupKey, string groupName);
        bool RemoveGroup(string groupKey);
        bool AddRoleToGroup(string groupKey, string roleId, string projectKey);
    }
}
