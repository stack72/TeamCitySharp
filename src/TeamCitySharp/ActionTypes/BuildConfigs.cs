using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using EasyHttp.Http;
using JsonFx.Json;
using JsonFx.Serialization;
using JsonFx.Serialization.Resolvers;
using TeamCitySharp.Connection;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.ActionTypes
{
  public class BuildConfigs : IBuildConfigs
  {
    private readonly ITeamCityCaller _caller;
    private string _fields;

    internal BuildConfigs(ITeamCityCaller caller)
    {
      _caller = caller;
    }

    public BuildConfigs GetFields(string fields)
    {
      var newInstance = (BuildConfigs) MemberwiseClone();
      newInstance._fields = fields;
      return newInstance;
    }

    public List<BuildConfig> All()
    {
      var buildType =
        _caller.Get<BuildTypeWrapper>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes", _fields));

      return buildType.BuildType;
    }

    public BuildConfig ByConfigurationName(string buildConfigName)
    {
      var build = _caller.GetFormat<BuildConfig>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/name:{0}", _fields),
                                                 buildConfigName);

      return build;
    }

    public BuildConfig ByConfigurationId(string buildConfigId)
    {
      var build = _caller.GetFormat<BuildConfig>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/id:{0}", _fields),
                                                 buildConfigId);

      return build;
    }

    public BuildConfig ByProjectNameAndConfigurationName(string projectName, string buildConfigName)
    {
      var build =
        _caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            string.Format("/app/rest/projects/name:{0}/buildTypes/name:{1}", projectName, buildConfigName), _fields));
      return build;
    }

    public BuildConfig ByProjectNameAndConfigurationId(string projectName, string buildConfigId)
    {
      var build =
        _caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            string.Format("/app/rest/projects/name:{0}/buildTypes/id:{1}", projectName, buildConfigId), _fields));
      return build;
    }

    public BuildConfig ByProjectIdAndConfigurationName(string projectId, string buildConfigName)
    {
      var build =
        _caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            string.Format("/app/rest/projects/id:{0}/buildTypes/name:{1}", projectId,
                          Uri.EscapeDataString(buildConfigName)), _fields));
      return build;
    }

    public BuildConfig ByProjectIdAndConfigurationId(string projectId, string buildConfigId)
    {
      var build =
        _caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            string.Format("/app/rest/projects/id:{0}/buildTypes/id:{1}", projectId, buildConfigId), _fields));
      return build;
    }

    public List<BuildConfig> ByProjectId(string projectId)
    {
      var buildWrapper =
        _caller.GetFormat<BuildTypeWrapper>(
          ActionHelper.CreateFieldUrl("/app/rest/projects/id:{0}/buildTypes", _fields), projectId);

      if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
      return buildWrapper.BuildType;
    }

    public List<BuildConfig> ByProjectName(string projectName)
    {
      var buildWrapper =
        _caller.GetFormat<BuildTypeWrapper>(
          ActionHelper.CreateFieldUrl("/app/rest/projects/name:{0}/buildTypes", _fields), projectName);

      if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
      return buildWrapper.BuildType;
    }

    public BuildConfig CreateConfiguration(string projectName, string configurationName)
    {
      return _caller.PostFormat<BuildConfig>(configurationName, HttpContentTypes.TextPlain,
                                             HttpContentTypes.ApplicationJson, "/app/rest/projects/name:{0}/buildTypes",
                                             projectName);
    }

    public BuildConfig CreateConfigurationByProjectId(string projectId, string configurationName)
    {
      return _caller.PostFormat<BuildConfig>(configurationName, HttpContentTypes.TextPlain,
                                             HttpContentTypes.ApplicationJson, "/app/rest/projects/id:{0}/buildTypes",
                                             projectId);
    }

    internal HttpResponse CopyBuildConfig(string buildConfigId, string buildConfigName, string destinationProjectId,
                                          string newBuildTypeId = "")
    {
      string xmlData;
      if (newBuildTypeId != "")
      {
        xmlData =
          String.Format(
            "<newBuildTypeDescription name='{0}' id='{2}' sourceBuildTypeLocator='id:{1}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>",
            buildConfigName, buildConfigId, newBuildTypeId);
      }
      else
      {
        xmlData =
          String.Format(
            "<newBuildTypeDescription name='{0}' sourceBuildTypeLocator='id:{1}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>",
            buildConfigName, buildConfigId);
      }
      var response = _caller.Post(xmlData, HttpContentTypes.ApplicationXml,
                                  string.Format("/app/rest/projects/id:{0}/buildTypes", destinationProjectId),
                                  HttpContentTypes.ApplicationJson);
      return response;
    }

    public BuildConfig Copy(string buildConfigId, string buildConfigName, string destinationProjectId,
                            string newBuildTypeId = "")
    {
      var response = CopyBuildConfig(buildConfigId, buildConfigName, destinationProjectId, newBuildTypeId);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var reader =
          new JsonReader(
            new DataReaderSettings(new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));
        var buildConfig = reader.Read<BuildConfig>(response.RawText);
        return buildConfig;
      }
      return new BuildConfig();
    }

    public Template CopyTemplate(string templateId, string templateName, string destinationProjectId,
                                 string newTemplateId = "")
    {
      var response = CopyTemplateQuery(templateId, templateName, destinationProjectId, newTemplateId);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var reader =
          new JsonReader(
            new DataReaderSettings(new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));
        var template = reader.Read<Template>(response.RawText);
        return template;
      }
      return new Template();
    }

    private HttpResponse CopyTemplateQuery(string templateId, string templateName, string destinationProjectId,
                                           string newTemplateId)
    {
      string xmlData;
      if (newTemplateId != "")
      {
        xmlData =
          String.Format(
            "<newBuildTypeDescription name='{0}' id='{2}' sourceBuildTypeLocator='id:{1}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>",
            templateName, templateId, newTemplateId);
      }
      else
      {
        xmlData =
          String.Format(
            "<newBuildTypeDescription name='{0}' sourceBuildTypeLocator='id:{1}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>",
            templateName, templateId);
      }
      var response = _caller.Post(xmlData, HttpContentTypes.ApplicationXml,
                                  string.Format("/app/rest/projects/id:{0}/templates", destinationProjectId),
                                  HttpContentTypes.ApplicationJson);
      return response;
    }

    public void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue)
    {
      _caller.PutFormat(settingValue, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/settings/{1}", locator,
                        settingName);
    }

    public bool GetConfigurationPauseStatus(BuildTypeLocator locator)
    {
      return _caller.Get<bool>(string.Format("/app/rest/buildTypes/{0}/paused/", locator.Name));
    }

    public void SetConfigurationPauseStatus(BuildTypeLocator locator, bool isPaused)
    {
      _caller.PutFormat(isPaused, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/paused/", locator);
    }

    public void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml)
    {
      _caller.PostFormat<ArtifactDependency>(rawXml, HttpContentTypes.ApplicationXml, string.Empty,
                                             "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
    }

    public void PostRawBuildStep(BuildTypeLocator locator, string rawXml)
    {
      _caller.PostFormat<BuildConfig>(rawXml, HttpContentTypes.ApplicationXml, string.Empty,
                                      "/app/rest/buildTypes/{0}/steps", locator);
    }

    public void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml)
    {
      _caller.PostFormat(rawXml, HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/triggers", locator);
    }

    public void SetArtifactDependency(BuildTypeLocator locator, ArtifactDependency dependency)
    {
      _caller.PostFormat<ArtifactDependency>(dependency, HttpContentTypes.ApplicationJson,
                                             HttpContentTypes.ApplicationJson,
                                             "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
    }

    public void SetSnapshotDependency(BuildTypeLocator locator, SnapshotDependency dependency)
    {
      _caller.PostFormat<SnapshotDependency>(dependency, HttpContentTypes.ApplicationJson,
                                             HttpContentTypes.ApplicationJson,
                                             "/app/rest/buildTypes/{0}/snapshot-dependencies", locator);
    }

    public void SetTrigger(BuildTypeLocator locator, BuildTrigger trigger)
    {
      _caller.PostFormat<BuildTrigger>(trigger, HttpContentTypes.ApplicationJson, HttpContentTypes.ApplicationJson,
                                       "/app/rest/buildTypes/{0}/triggers", locator);
    }

    public void SetConfigurationParameter(BuildTypeLocator locator, string key, string value)
    {
      _caller.PutFormat(value, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/parameters/{1}", locator, key);
    }

    public void DeleteConfiguration(BuildTypeLocator locator)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}", locator);
    }

    public void DeleteAllBuildTypeParameters(BuildTypeLocator locator)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/parameters", locator);
    }

    public void PutAllBuildTypeParameters(BuildTypeLocator locator, IDictionary<string, string> parameters)
    {
      if (locator == null) throw new ArgumentNullException("locator");
      if (parameters == null) throw new ArgumentNullException("parameters");

      var sw = new StringWriter();
      using (var writer = new XmlTextWriter(sw))
      {
        writer.WriteStartElement("properties");
        foreach (var parameter in parameters)
        {
          writer.WriteStartElement("property");
          writer.WriteAttributeString("name", parameter.Key);
          writer.WriteAttributeString("value", parameter.Value);
          writer.WriteEndElement();
        }
        writer.WriteEndElement();
      }

      _caller.PutFormat(sw.ToString(), HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/parameters", locator);
    }

    public void DownloadConfiguration(BuildTypeLocator locator, Action<string> downloadHandler)
    {
      var url = string.Format("/app/rest/buildTypes/{0}", locator);
      _caller.GetDownloadFormat(downloadHandler, url);
    }

    public void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml)
    {
      _caller.PostFormat(rawXml, HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/agent-requirements", locator);
    }

    public void DeleteBuildStep(BuildTypeLocator locator, string buildStepId)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/steps/{1}", locator, buildStepId);
    }

    public void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/artifact-dependencies/{1}", locator, artifactDependencyId);
    }

    public void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/agent-requirements/{1}", locator, agentRequirementId);
    }

    public void DeleteParameter(BuildTypeLocator locator, string parameterName)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/parameters/{1}", locator, parameterName);
    }

    public void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/triggers/{1}", locator, buildTriggerId);
    }

    public void SetBuildTypeTemplate(BuildTypeLocator locatorBuildType, BuildTypeLocator locatorTemplate)
    {
      _caller.PutFormat(locatorTemplate.ToString(), HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/template",
                        locatorBuildType);
    }

    public void DeleteSnapshotDependency(BuildTypeLocator locator, string snapshotDependencyId)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/snapshot-dependencies/{1}", locator, snapshotDependencyId);
    }

    public void PostRawSnapshotDependency(BuildTypeLocator locator, XmlElement rawXml)
    {
      _caller.PostFormat(rawXml.OuterXml, HttpContentTypes.ApplicationXml,
                         "/app/rest/buildTypes/{0}/snapshot-dependencies", locator);
    }

    public BuildConfig BuildType(BuildTypeLocator locator)
    {
      var build = _caller.GetFormat<BuildConfig>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/{0}", _fields),
                                                 locator);

      return build;
    }

    public void SetBuildTypeVariable(BuildTypeLocator locatorBuildType, string nameVariable, string value)
    {
      _caller.PutFormat(value, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/{1}", locatorBuildType,
                        nameVariable);
    }

    public bool ModifTrigger(string buildTypeId, string triggerId, string newBt)
    {
      //Get data from the old trigger
      var urlExtractAllTriggersOld = String.Format("/app/rest/buildTypes/id:{0}/triggers", buildTypeId);
      var triggers = _caller.GetFormat<BuildTriggers>(urlExtractAllTriggersOld);
      foreach (var trigger in triggers.Trigger.OrderByDescending(m => m.Id))
      {
        if (trigger.Type != "buildDependencyTrigger") continue;

        foreach (var property in trigger.Properties.Property)
        {
          if (property.Name != "dependsOn") continue;

          if (triggerId != property.Value) continue;

          property.Value = newBt;
          var writer =
            new JsonWriter(
              new DataWriterSettings(new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));
          var ttt = writer.Write(trigger);
          var urlNewTrigger = String.Format("/app/rest/buildTypes/id:{0}/triggers", buildTypeId);
          var response = _caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger,
                                      HttpContentTypes.ApplicationJson);
          if (response.StatusCode != HttpStatusCode.OK) continue;

          var urlDeleteOld = String.Format("/app/rest/buildTypes/id:{0}/triggers/{1}", buildTypeId, trigger.Id);
          _caller.Delete(urlDeleteOld);
          if (response.StatusCode == HttpStatusCode.OK)
            return true;
        }
      }
      return false;
    }

    public bool ModifSnapshotDependencies(string buildTypeId, string dependencyId, string newBt)
    {
      var urlExtractOld = String.Format("/app/rest/buildTypes/id:{0}/snapshot-dependencies/{1}", buildTypeId,
                                        dependencyId);
      var snapshot = _caller.GetFormat<SnapshotDependency>(urlExtractOld);
      snapshot.Id = newBt;
      snapshot.SourceBuildType.Id = newBt;

      var urlNewTrigger = String.Format("/app/rest/buildTypes/id:{0}/snapshot-dependencies", buildTypeId);
      var writer =
        new JsonWriter(
          new DataWriterSettings(new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));

      var ttt = (writer.Write(snapshot));
      ttt = Regex.Replace(ttt, "source-build-type", "source-buildType");


      var response = _caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger, HttpContentTypes.ApplicationJson);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var urlDeleteOld = String.Format("/app/rest/buildTypes/id:{0}/snapshot-dependencies/{1}", buildTypeId,
                                         dependencyId);
        _caller.Delete(urlDeleteOld);
        if (response.StatusCode == HttpStatusCode.OK)
          return true;
      }

      return false;
    }

    public bool ModifArtifactDependencies(string buildTypeId, string dependencyId, string newBt)
    {
      var urlAllExtractOld = String.Format("/app/rest/buildTypes/id:{0}/artifact-dependencies", buildTypeId);
      var artifacts = _caller.GetFormat<ArtifactDependencies>(urlAllExtractOld);
      foreach (var artifact in artifacts.ArtifactDependency.OrderByDescending(m => m.Id))
      {
        if (dependencyId != artifact.SourceBuildType.Id) continue;
        artifact.SourceBuildType.Id = newBt;
        var writer =
          new JsonWriter(
            new DataWriterSettings(new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));
        var ttt = writer.Write(artifact);
        ttt = Regex.Replace(ttt, "source-build-type", "source-buildType");

        var urlNewTrigger = String.Format("/app/rest/buildTypes/id:{0}/artifact-dependencies", buildTypeId);

        var response = _caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger,
                                    HttpContentTypes.ApplicationJson);
        if (response.StatusCode == HttpStatusCode.OK)
        {
          var urlDeleteOld = String.Format("/app/rest/buildTypes/id:{0}/artifact-dependencies/{1}", buildTypeId,
                                           artifact.Id);
          _caller.Delete(urlDeleteOld);
          return response.StatusCode == HttpStatusCode.OK;
        }
      }

      return false;
    }

    public Template GetTemplate(BuildTypeLocator locator)
    {
      try
      {
        var templatedWrapper =
          _caller.GetFormat<Template>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/{0}/template", _fields), locator);
        return templatedWrapper;
      }
      catch
      {
        return null;
      }
    }

    public void AttachTemplate(BuildTypeLocator locator, string templateId)
    {
      _caller.PutFormat(templateId, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/template", locator);
    }


    public void DetachTemplate(BuildTypeLocator locator)
    {
      _caller.DeleteFormat("/app/rest/buildTypes/{0}/template", locator);
    }
  }
}