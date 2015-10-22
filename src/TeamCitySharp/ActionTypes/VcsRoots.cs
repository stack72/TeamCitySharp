using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyHttp.Http;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
    internal class VcsRoots: IVcsRoots
    {
        private readonly TeamCityCaller _caller;

        internal VcsRoots(TeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<VcsRoot> All()
        {
            var vcsRootWrapper = _caller.Get<VcsRootWrapper>("/app/rest/vcs-roots");

            return vcsRootWrapper.VcsRoot;
        }

        public VcsRoot ById(string vcsRootId)
        {
            var vcsRoot = _caller.GetFormat<VcsRoot>("/app/rest/vcs-roots/id:{0}", vcsRootId);

            return vcsRoot;
        }


        public VcsRoot Create(VcsRoot root)
        {
            var sb = new StringBuilder();
            var rootStr = 
                string.Format(
                @"<vcs-root id=""{0}"" name=""{1}"" vcsName=""{2}"" status=""{3}"">"
                ,root.Id,root.Name,root.vcsName,root.Status);
            sb.Append(rootStr);
            var projectStr = 
                string.Format(
                @"<project id=""{0}"" name=""{1}"" />"
                ,root.Project.Id,root.Project.Name);
            sb.Append(projectStr);
            if (root.Properties != null && root.Properties.Property != null && root.Properties.Property.Any())
            {
                sb.Append(string.Format(@"<properties count=""{0}"">", root.Properties.Property.Count));
                foreach (var property in root.Properties.Property)
                {
                    sb.Append(string.Format(@"<property name = ""{0}"" value = ""{1}""/>", property.Name, property.Value));
                }
                sb.Append(@"</properties>");
            }
            sb.Append("</vcs-root>");
            var xml = sb.ToString();

            return _caller.PostFormat<VcsRoot>(xml, HttpContentTypes.ApplicationXml, HttpContentTypes.ApplicationJson, "/app/rest/vcs-roots/");
        }

        public VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot)
        {
            var xml = string.Format(@"<vcs-root-entry><vcs-root id=""{0}""/></vcs-root-entry>", vcsRoot.Id);
            return _caller.PostFormat<VcsRoot>(xml, HttpContentTypes.ApplicationXml, string.Empty, "/app/rest/buildTypes/{0}/vcs-root-entries", locator);	
        }

        public void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/vcs-root-entries/{1}", locator, vcsRootId);
        }

        public void SetVcsRootField(VcsRoot vcsRoot, VcsRootField field, object value)
        {
            _caller.PutFormat(value, "/app/rest/vcs-roots/id:{0}/{1}", vcsRoot.Id, ToCamelCase(field.ToString()));
        }

        private static string ToCamelCase(string s)
        {
            return Char.ToLower(s.ToCharArray()[0]) + s.Substring(1);
        }
    }
}