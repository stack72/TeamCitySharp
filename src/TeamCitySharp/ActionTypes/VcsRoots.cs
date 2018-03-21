using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using EasyHttp.Http;
using JsonFx.Json;
using JsonFx.Json.Resolvers;
using JsonFx.Serialization;
using JsonFx.Serialization.Resolvers;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public class VcsRoots : IVcsRoots
  {
    private readonly ITeamCityCaller m_caller;
    private string m_fields;

    internal VcsRoots(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public VcsRoots GetFields(string fields)
    {
      var newInstance = (VcsRoots) MemberwiseClone();
      newInstance.m_fields = fields;
      return newInstance;
    }

    public List<VcsRoot> All()
    {
      var vcsRootWrapper = m_caller.Get<VcsRootWrapper>(ActionHelper.CreateFieldUrl("/app/rest/vcs-roots", m_fields));

      return vcsRootWrapper.VcsRoot;
    }

    public VcsRoot ById(string vcsRootId)
    {
      var vcsRoot = m_caller.GetFormat<VcsRoot>(ActionHelper.CreateFieldUrl("/app/rest/vcs-roots/id:{0}", m_fields),
                                               vcsRootId);

      return vcsRoot;
    }

    public VcsRoot AttachVcsRoot(BuildTypeLocator locator, VcsRoot vcsRoot)
    {
      var xml = $@"<vcs-root-entry><vcs-root id=""{vcsRoot.Id}""/></vcs-root-entry>";
      return m_caller.PostFormat<VcsRoot>(xml, HttpContentTypes.ApplicationXml, string.Empty,
                                         "/app/rest/buildTypes/{0}/vcs-root-entries", locator);
    }

    public void DetachVcsRoot(BuildTypeLocator locator, string vcsRootId)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/vcs-root-entries/{1}", locator, vcsRootId);
    }

    public void SetVcsRootValue(VcsRoot vcsRoot, VcsRootValue field, object value)
    {
      m_caller.PutFormat(value, HttpContentTypes.TextPlain, "/app/rest/vcs-roots/id:{0}/{1}", vcsRoot.Id,
        ToCamelCase(field.ToString()));
    }

    public void SetConfigurationProperties(VcsRoot vcsRoot, string key, string value)
    {
      m_caller.PutFormat(value, HttpContentTypes.TextPlain, "/app/rest/vcs-roots/id:{0}/properties/{1}", vcsRoot.Id, key);
    }

    public void DeleteProperties(VcsRoot vcsRoot, string parameterName)
    {
      m_caller.DeleteFormat("/app/rest/vcs-roots/id:{0}/properties/{1}", vcsRoot.Id, parameterName);
    }

    public VcsRoot CreateVcsRoot(VcsRoot vcsRoot, string projectId )
    {
      var writer =
        new JsonWriter(
          new DataWriterSettings(new JsonResolverStrategy()));
      var data = writer.Write(vcsRoot);

      return m_caller.PostFormat<VcsRoot>(data, HttpContentTypes.ApplicationJson,
          HttpContentTypes.ApplicationJson, "/app/rest/vcs-roots",
          projectId);
     
    }
    public void DeleteVcsRoot(VcsRoot vcsRoot)
    {
      m_caller.DeleteFormat("/app/rest/vcs-roots/id:{0}", vcsRoot.Id);
    }

    private static string ToCamelCase(string s)
    {
      return Char.ToLower(s.ToCharArray()[0]) + s.Substring(1);
    }
  }
}