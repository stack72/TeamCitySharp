using System;
using System.Collections.Generic;
using EasyHttp.Http;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  internal class VcsRoots : IVcsRoots
  {
    private readonly ITeamCityCaller _caller;
    private string _fields;

    internal VcsRoots(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public VcsRoots GetFields(string fields)
    {
      var newInstance = (VcsRoots) MemberwiseClone();
      newInstance._fields = fields;
      return newInstance;
    }

    public List<VcsRoot> All()
    {
      var vcsRootWrapper = _caller.Get<VcsRootWrapper>(ActionHelper.CreateFieldUrl("/app/rest/vcs-roots", _fields));

      return vcsRootWrapper.VcsRoot;
    }

    public VcsRoot ById(string vcsRootId)
    {
      var vcsRoot = _caller.GetFormat<VcsRoot>(ActionHelper.CreateFieldUrl("/app/rest/vcs-roots/id:{0}", _fields),
                                               vcsRootId);

      return vcsRoot;
    }

    public VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot)
    {
      var xml = string.Format(@"<vcs-root-entry><vcs-root id=""{0}""/></vcs-root-entry>", vcsRoot.Id);
      return _caller.PostFormat<VcsRoot>(xml, HttpContentTypes.ApplicationXml, string.Empty,
                                         "/app/rest/buildTypes/{0}/vcs-root-entries", locator);
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