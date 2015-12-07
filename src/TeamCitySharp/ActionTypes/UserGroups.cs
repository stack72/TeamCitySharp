using System.Collections.Generic;
using System.Net;

using EasyHttp.Http;

using TeamCitySharp.Connection;
using TeamCitySharp.Util;

namespace TeamCitySharp.ActionTypes
{

    internal class UserGroups : IUserGroups
    {
        private readonly TeamCityCaller _caller;

        internal UserGroups(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public bool AddGroup(string groupKey, string groupName)
        {
            ArgumentUtil.CheckNotNull(() => groupKey, () => groupName);

            var attributesDictionary = new Dictionary<string, string> { { "key", groupKey }, { "name", groupName } };
            var payload = XmlUtil.SingleElementDocument("role", attributesDictionary);
            var response = _caller.Post(payload, HttpContentTypes.ApplicationXml, "/app/rest/userGroups", null);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool AddRoleToGroup(string groupKey, string roleId, string projectKey)
        {
            ArgumentUtil.CheckNotNull(() => groupKey, () => roleId, () => projectKey);

            var attributesDictionary = new Dictionary<string, string> { { "roleId", roleId }, { "scope", string.Format("p:{0}", projectKey) } };
            var payload = XmlUtil.SingleElementDocument("role", attributesDictionary);
            var response = _caller.Post(payload, HttpContentTypes.ApplicationXml, string.Format("/app/rest/userGroups/key:{0}/roles", groupKey), null);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}
