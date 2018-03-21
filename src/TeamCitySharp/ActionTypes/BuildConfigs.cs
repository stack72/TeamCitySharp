using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
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
  public class BuildConfigs : IBuildConfigs
  {
    private readonly ITeamCityCaller m_caller;
    private string m_fields;

    internal BuildConfigs(ITeamCityCaller caller)
    {
      m_caller = caller;
    }

    public BuildConfigs GetFields(string fields)
    {
      var newInstance = (BuildConfigs) MemberwiseClone();
      newInstance.m_fields = fields;
      return newInstance;
    }

    public List<BuildConfig> All()
    {
      var buildType =
        m_caller.Get<BuildTypeWrapper>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes", m_fields));

      return buildType.BuildType;
    }

    public BuildConfig ByConfigurationName(string buildConfigName)
    {
      var build = m_caller.GetFormat<BuildConfig>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/name:{0}", m_fields),
                                                 buildConfigName);

      return build;
    }

    public BuildConfig ByConfigurationId(string buildConfigId)
    {
      var build = m_caller.GetFormat<BuildConfig>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/id:{0}", m_fields),
                                                 buildConfigId);

      return build;
    }

    public BuildConfig ByProjectNameAndConfigurationName(string projectName, string buildConfigName)
    {
      var build =
        m_caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            $"/app/rest/projects/name:{projectName}/buildTypes/name:{buildConfigName}", m_fields));
      return build;
    }

    public BuildConfig ByProjectNameAndConfigurationId(string projectName, string buildConfigId)
    {
      var build =
        m_caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            $"/app/rest/projects/name:{projectName}/buildTypes/id:{buildConfigId}", m_fields));
      return build;
    }

    public BuildConfig ByProjectIdAndConfigurationName(string projectId, string buildConfigName)
    {
      var build =
        m_caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            $"/app/rest/projects/id:{projectId}/buildTypes/name:{Uri.EscapeDataString(buildConfigName)}", m_fields));
      return build;
    }

    public BuildConfig ByProjectIdAndConfigurationId(string projectId, string buildConfigId)
    {
      var build =
        m_caller.Get<BuildConfig>(
          ActionHelper.CreateFieldUrl(
            $"/app/rest/projects/id:{projectId}/buildTypes/id:{buildConfigId}", m_fields));
      return build;
    }

    public List<BuildConfig> ByProjectId(string projectId)
    {
      var buildWrapper =
        m_caller.GetFormat<BuildTypeWrapper>(
          ActionHelper.CreateFieldUrl("/app/rest/projects/id:{0}/buildTypes", m_fields), projectId);

      return buildWrapper?.BuildType ?? new List<BuildConfig>();
    }

    public List<BuildConfig> ByProjectName(string projectName)
    {
      var buildWrapper =
        m_caller.GetFormat<BuildTypeWrapper>(
          ActionHelper.CreateFieldUrl("/app/rest/projects/name:{0}/buildTypes", m_fields), projectName);

      return buildWrapper?.BuildType ?? new List<BuildConfig>();
    }

    public BuildConfig CreateConfiguration(string projectName, string configurationName)
    {
      return m_caller.PostFormat<BuildConfig>(configurationName, HttpContentTypes.TextPlain,
                                             HttpContentTypes.ApplicationJson, "/app/rest/projects/name:{0}/buildTypes",
                                             projectName);
    }

    public BuildConfig CreateConfigurationByProjectId(string projectId, string configurationName)
    {
      return m_caller.PostFormat<BuildConfig>(configurationName, HttpContentTypes.TextPlain,
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
          string.Format(
            "<newBuildTypeDescription name='{0}' id='{2}' sourceBuildTypeLocator='id:{1}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>",
            buildConfigName, buildConfigId, newBuildTypeId);
      }
      else
      {
        xmlData =
          $"<newBuildTypeDescription name='{buildConfigName}' sourceBuildTypeLocator='id:{buildConfigId}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>";
      }
      var response = m_caller.Post(xmlData, HttpContentTypes.ApplicationXml,
        $"/app/rest/projects/id:{destinationProjectId}/buildTypes",
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
      var xmlData = newTemplateId != ""
        ? $"<newBuildTypeDescription name='{templateName}' id='{newTemplateId}' sourceBuildTypeLocator='id:{templateId}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>"
        : $"<newBuildTypeDescription name='{templateName}' sourceBuildTypeLocator='id:{templateId}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>";
      var response = m_caller.Post(xmlData, HttpContentTypes.ApplicationXml,
        $"/app/rest/projects/id:{destinationProjectId}/templates",
                                  HttpContentTypes.ApplicationJson);
      return response;
    }

    public void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue)
    {
      m_caller.PutFormat(settingValue, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/settings/{1}", locator,
                        settingName);
    }

    public bool GetConfigurationPauseStatus(BuildTypeLocator locator)
    {
      return m_caller.Get<bool>($"/app/rest/buildTypes/{locator.Name}/paused/");
    }

    public void SetConfigurationPauseStatus(BuildTypeLocator locator, bool isPaused)
    {
      m_caller.PutFormat(isPaused, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/paused/", locator);
    }

    public void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml)
    {
      m_caller.PostFormat<ArtifactDependency>(rawXml, HttpContentTypes.ApplicationXml, HttpContentTypes.ApplicationJson,
                                             "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
    }

    public void PostRawBuildStep(BuildTypeLocator locator, string rawXml)
    {
      m_caller.PostFormat<BuildConfig>(rawXml, HttpContentTypes.ApplicationXml, HttpContentTypes.ApplicationJson,
                                      "/app/rest/buildTypes/{0}/steps", locator);
    }

    public void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml)
    {
      m_caller.PostFormat(rawXml, HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/triggers", locator);
    }

    public void SetArtifactDependency(BuildTypeLocator locator, ArtifactDependency dependency)
    {
      m_caller.PostFormat<ArtifactDependency>(dependency, HttpContentTypes.ApplicationJson,
                                             HttpContentTypes.ApplicationJson,
                                             "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
    }

    public void SetSnapshotDependency(BuildTypeLocator locator, SnapshotDependency dependency)
    {
      m_caller.PostFormat<SnapshotDependency>(dependency, HttpContentTypes.ApplicationJson,
                                             HttpContentTypes.ApplicationJson,
                                             "/app/rest/buildTypes/{0}/snapshot-dependencies", locator);
    }

    public void SetTrigger(BuildTypeLocator locator, BuildTrigger trigger)
    {
      m_caller.PostFormat<BuildTrigger>(trigger, HttpContentTypes.ApplicationJson, HttpContentTypes.ApplicationJson,
                                       "/app/rest/buildTypes/{0}/triggers", locator);
    }

    public void SetConfigurationParameter(BuildTypeLocator locator, string key, string value)
    {
      m_caller.PutFormat(value, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/parameters/{1}", locator, key);
    }

    public void DeleteConfiguration(BuildTypeLocator locator)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}", locator);
    }

    public void DeleteAllBuildTypeParameters(BuildTypeLocator locator)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/parameters", locator);
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

      m_caller.PutFormat(sw.ToString(), HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/parameters", locator);
    }

    public void DownloadConfiguration(BuildTypeLocator locator, Action<string> downloadHandler)
    {
      var url = $"/app/rest/buildTypes/{locator}";
      m_caller.GetDownloadFormat(downloadHandler, url);
    }

    public void PostRawAgentRequirement(BuildTypeLocator locator, string rawXml)
    {
      m_caller.PostFormat(rawXml, HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/agent-requirements", locator);
    }

    public void DeleteBuildStep(BuildTypeLocator locator, string buildStepId)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/steps/{1}", locator, buildStepId);
    }

    public void DeleteArtifactDependency(BuildTypeLocator locator, string artifactDependencyId)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/artifact-dependencies/{1}", locator, artifactDependencyId);
    }

    public void DeleteAgentRequirement(BuildTypeLocator locator, string agentRequirementId)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/agent-requirements/{1}", locator, agentRequirementId);
    }

    public void DeleteParameter(BuildTypeLocator locator, string parameterName)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/parameters/{1}", locator, parameterName);
    }

    public void DeleteBuildTrigger(BuildTypeLocator locator, string buildTriggerId)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/triggers/{1}", locator, buildTriggerId);
    }

    public void SetBuildTypeTemplate(BuildTypeLocator locatorBuildType, BuildTypeLocator locatorTemplate)
    {
      m_caller.PutFormat(locatorTemplate.ToString(), HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/template",
                        locatorBuildType);
    }

    public void DeleteSnapshotDependency(BuildTypeLocator locator, string snapshotDependencyId)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/snapshot-dependencies/{1}", locator, snapshotDependencyId);
    }

    public void PostRawSnapshotDependency(BuildTypeLocator locator, XmlElement rawXml)
    {
      m_caller.PostFormat(rawXml.OuterXml, HttpContentTypes.ApplicationXml,
                         "/app/rest/buildTypes/{0}/snapshot-dependencies", locator);
    }

    public BuildConfig BuildType(BuildTypeLocator locator)
    {
      var build = m_caller.GetFormat<BuildConfig>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/{0}", m_fields),
                                                 locator);

      return build;
    }

    public void SetBuildTypeVariable(BuildTypeLocator locatorBuildType, string nameVariable, string value)
    {
      m_caller.PutFormat(value, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/{1}", locatorBuildType,
                        nameVariable);
    }

    public bool ModifTrigger(string buildTypeId, string triggerId, string newBt)
    {
      //Get data from the old trigger
      var urlExtractAllTriggersOld = $"/app/rest/buildTypes/id:{buildTypeId}/triggers";
      var triggers = m_caller.GetFormat<BuildTriggers>(urlExtractAllTriggersOld);
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
              new DataWriterSettings(new JsonResolverStrategy()));
          var ttt = writer.Write(trigger);
          var urlNewTrigger = $"/app/rest/buildTypes/id:{buildTypeId}/triggers";
          var response = m_caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger,
                                      HttpContentTypes.ApplicationJson);
          if (response.StatusCode != HttpStatusCode.OK) continue;

          var urlDeleteOld = $"/app/rest/buildTypes/id:{buildTypeId}/triggers/{trigger.Id}";
          m_caller.Delete(urlDeleteOld);
          if (response.StatusCode == HttpStatusCode.OK)
            return true;
        }
      }
      return false;
    }

    public bool ModifSnapshotDependencies(string buildTypeId, string dependencyId, string newBt)
    {
      var urlExtractOld = $"/app/rest/buildTypes/id:{buildTypeId}/snapshot-dependencies/{dependencyId}";
      var snapshot = m_caller.GetFormat<SnapshotDependency>(urlExtractOld);
      snapshot.Id = newBt;
      snapshot.SourceBuildType.Id = newBt;

      var urlNewTrigger = $"/app/rest/buildTypes/id:{buildTypeId}/snapshot-dependencies";
      var writer =
        new JsonWriter(
          new DataWriterSettings(new JsonResolverStrategy()));

      var tmpArtifact = (writer.Write(snapshot));
      tmpArtifact = Regex.Replace(tmpArtifact, "source-build-type", "source-buildType");


      var response = m_caller.Post(tmpArtifact, HttpContentTypes.ApplicationJson, urlNewTrigger, HttpContentTypes.ApplicationJson);
      if (response.StatusCode == HttpStatusCode.OK)
      {
        var urlDeleteOld = $"/app/rest/buildTypes/id:{buildTypeId}/snapshot-dependencies/{dependencyId}";
        m_caller.Delete(urlDeleteOld);
        if (response.StatusCode == HttpStatusCode.OK)
          return true;
      }

      return false;
    }

    public bool ModifArtifactDependencies(string buildTypeId, string dependencyId, string newBt)
    {
      var urlAllExtractOld = $"/app/rest/buildTypes/id:{buildTypeId}/artifact-dependencies";
      var artifacts = m_caller.GetFormat<ArtifactDependencies>(urlAllExtractOld);
      foreach (var artifact in artifacts.ArtifactDependency.OrderByDescending(m => m.Id))
      {
        if (dependencyId != artifact.SourceBuildType.Id) continue;
        artifact.SourceBuildType.Id = newBt;
        var writer =
          new JsonWriter(
            new DataWriterSettings(new JsonResolverStrategy()));
        var tmpArtifact = writer.Write(artifact);
        tmpArtifact = Regex.Replace(tmpArtifact, "source-build-type", "source-buildType");

        var urlNewTrigger = $"/app/rest/buildTypes/id:{buildTypeId}/artifact-dependencies";

        var response = m_caller.Post(tmpArtifact, HttpContentTypes.ApplicationJson, urlNewTrigger,
                                    HttpContentTypes.ApplicationJson);
        if (response.StatusCode == HttpStatusCode.OK)
        {
          var urlDeleteOld = $"/app/rest/buildTypes/id:{buildTypeId}/artifact-dependencies/{artifact.Id}";
          m_caller.Delete(urlDeleteOld);
          return response.StatusCode == HttpStatusCode.OK;
        }
      }

      return false;
    }

    public ArtifactDependencies GetArtifactDependencies(string buildTypeId)
    {
      var artifactDependencies =
        m_caller.Get<ArtifactDependencies>(
          ActionHelper.CreateFieldUrl(
            $"/app/rest/buildTypes/id:{buildTypeId}/artifact-dependencies", m_fields));
      return artifactDependencies;
    }
    public SnapshotDependencies GetSnapshotDependencies(string buildTypeId)
    {
      var snapshotDependencies =
        m_caller.Get<SnapshotDependencies>(
          ActionHelper.CreateFieldUrl(
            $"/app/rest/buildTypes/id:{buildTypeId}/snapshot-dependencies", m_fields));
      return snapshotDependencies;
    }

    public Template GetTemplate(BuildTypeLocator locator)
    {
      try
      {
        var templatedWrapper =
          m_caller.GetFormat<Template>(ActionHelper.CreateFieldUrl("/app/rest/buildTypes/{0}/template", m_fields), locator);
        return templatedWrapper;
      }
      catch
      {
        return null;
      }
    }

    public void AttachTemplate(BuildTypeLocator locator, string templateId)
    {
      m_caller.PutFormat(templateId, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/template", locator);
    }


    public void DetachTemplate(BuildTypeLocator locator)
    {
      m_caller.DeleteFormat("/app/rest/buildTypes/{0}/template", locator);
    }
  }
}