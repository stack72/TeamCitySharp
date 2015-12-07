namespace TeamCitySharp.ActionTypes
{
    public interface IUserGroups
    {
        bool AddGroup(string groupKey, string groupName);
        bool AddRoleToGroup(string groupKey, string roleId, string projectKey);
    }
}
