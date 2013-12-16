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
    internal class BuildConfigs : IBuildConfigs
    {
        private readonly ITeamCityCaller _caller;

        internal BuildConfigs(ITeamCityCaller caller)
        {
            _caller = caller;
        }

        public List<BuildConfig> All()
        {
            var buildType = _caller.Get<BuildTypeWrapper>("/app/rest/buildTypes");

            return buildType.BuildType;
        }

        public BuildConfig ByConfigurationName(string buildConfigName)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/name:{0}", buildConfigName);

            return build;
        }

        public BuildConfig ByConfigurationId(string buildConfigId)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/id:{0}", buildConfigId);

            return build;
        }

        public BuildConfig ByProjectNameAndConfigurationName(string projectName, string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/name:{1}", projectName, buildConfigName));
            return build;
        }

        public BuildConfig ByProjectNameAndConfigurationId(string projectName, string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/name:{0}/buildTypes/id:{1}", projectName, buildConfigId));
            return build;
        }

        public BuildConfig ByProjectIdAndConfigurationName(string projectId, string buildConfigName)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/name:{1}", projectId, buildConfigName));
            return build;
        }

        public BuildConfig ByProjectIdAndConfigurationId(string projectId, string buildConfigId)
        {
            var build = _caller.Get<BuildConfig>(string.Format("/app/rest/projects/id:{0}/buildTypes/id:{1}", projectId, buildConfigId));
            return build;
        }

        public List<BuildConfig> ByProjectId(string projectId)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/id:{0}/buildTypes", projectId);

            if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
            return buildWrapper.BuildType;
        }

        public List<BuildConfig> ByProjectName(string projectName)
        {
            var buildWrapper = _caller.GetFormat<BuildTypeWrapper>("/app/rest/projects/name:{0}/buildTypes", projectName);

            if (buildWrapper == null || buildWrapper.BuildType == null) return new List<BuildConfig>();
            return buildWrapper.BuildType;
        }

        public BuildConfig CreateConfiguration(string projectName, string configurationName)
        {
            return _caller.PostFormat<BuildConfig>(configurationName, HttpContentTypes.TextPlain, HttpContentTypes.ApplicationJson, "/app/rest/projects/name:{0}/buildTypes", projectName);
        }

        public void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue)
        {
            _caller.PutFormat(settingValue, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/settings/{1}", locator, settingName);
        }

        public void PostRawArtifactDependency(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat<ArtifactDependency>(rawXml, HttpContentTypes.ApplicationXml, string.Empty, "/app/rest/buildTypes/{0}/artifact-dependencies", locator);
        }

        public void PostRawBuildStep(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat<BuildConfig>(rawXml, HttpContentTypes.ApplicationXml, string.Empty, "/app/rest/buildTypes/{0}/steps", locator);
        }

        public void PostRawBuildTrigger(BuildTypeLocator locator, string rawXml)
        {
            _caller.PostFormat(rawXml, HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/triggers", locator);
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
            if(locator == null)
                throw new ArgumentNullException("locator");
            if(parameters == null)
                throw new ArgumentNullException("parameters");

            var sw = new StringWriter();
            using(var writer = new XmlTextWriter(sw))
            {
                writer.WriteStartElement("properties");
                foreach(var parameter in parameters)
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
            _caller.PutFormat(locatorTemplate.ToString(), HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/template", locatorBuildType);
        }

        public void DeleteSnapshotDependency(BuildTypeLocator locator, string snapshotDependencyId)
        {
            _caller.DeleteFormat("/app/rest/buildTypes/{0}/snapshot-dependencies/{1}", locator, snapshotDependencyId);
        }

        public void PostRawSnapshotDependency(BuildTypeLocator locator, XmlElement rawXml)
        {
            _caller.PostFormat(rawXml.OuterXml, HttpContentTypes.ApplicationXml, "/app/rest/buildTypes/{0}/snapshot-dependencies", locator);
        }

        public BuildConfig BuildType(BuildTypeLocator locator)
        {
            var build = _caller.GetFormat<BuildConfig>("/app/rest/buildTypes/{0}", locator);

            return build;
        }
        public bool ModifTrigger(string buildTypeId, string triggerID, string newBt)
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

                if (triggerID != property.Value) continue;

                property.Value = newBt;
                var writer = new JsonWriter(new DataWriterSettings(new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));
                var ttt = writer.Write(trigger);
                var urlNewTrigger = String.Format("/app/rest/buildTypes/id:{0}/triggers", buildTypeId);
                var response = _caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger, HttpContentTypes.ApplicationJson);
                if (response.StatusCode != HttpStatusCode.OK) continue;

                var urlDeleteOld = String.Format("/app/rest/buildTypes/id:{0}/triggers/{1}", buildTypeId, trigger.Id);
                _caller.Delete(urlDeleteOld);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                  return true;
                }
              }
            }
          return false;
        }

        public bool ModifSnapshotDependencies(string buildTypeId, string dependencyId, string newBt)
        {

            var urlExtractOld = String.Format("/app/rest/buildTypes/id:{0}/snapshot-dependencies/{1}",
                                              buildTypeId, dependencyId);
            var snapshot = _caller.GetFormat<SnapshotDependency>(urlExtractOld);
            snapshot.Id = newBt;
            snapshot.SourceBuildType.Id = newBt;

            var urlNewTrigger = String.Format("/app/rest/buildTypes/id:{0}/snapshot-dependencies",
                                              buildTypeId);
            var writer =
                new JsonWriter(
                    new DataWriterSettings(
                        new ConventionResolverStrategy(ConventionResolverStrategy.WordCasing.Lowercase, "-")));

            var ttt = (writer.Write(snapshot));
            ttt = Regex.Replace(ttt, "source-build-type", "source-buildType");


            var response = _caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger, HttpContentTypes.ApplicationJson);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var urlDeleteOld = String.Format("/app/rest/buildTypes/id:{0}/snapshot-dependencies/{1}",
                                                 buildTypeId, dependencyId);
                _caller.Delete(urlDeleteOld);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ModifArtifactDependencies(string buildTypeId, string dependencyId, string newBt)
        {

            var urlAllExtractOld = String.Format("/app/rest/buildTypes/id:{0}/artifact-dependencies", 
                                                 buildTypeId);
            var artifacts = _caller.GetFormat<ArtifactDependencies>(urlAllExtractOld);
            foreach (var artifact in artifacts.ArtifactDependency.OrderByDescending(m => m.Id))
            {
                if (dependencyId != artifact.SourceBuildType.Id) continue;
                artifact.SourceBuildType.Id = newBt;
                var writer =
                    new JsonWriter(
                        new DataWriterSettings(
                            new ConventionResolverStrategy(
                                ConventionResolverStrategy.WordCasing.Lowercase, "-")));
                var ttt = writer.Write(artifact);
                ttt = Regex.Replace(ttt, "source-build-type", "source-buildType");

                var urlNewTrigger = String.Format(
                    "/app/rest/buildTypes/id:{0}/artifact-dependencies", buildTypeId);

                var response = _caller.Post(ttt, HttpContentTypes.ApplicationJson, urlNewTrigger, 
                                            HttpContentTypes.ApplicationJson);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var urlDeleteOld =
                        String.Format("/app/rest/buildTypes/id:{0}/artifact-dependencies/{1}",
                                      buildTypeId, artifact.Id);
                    _caller.Delete(urlDeleteOld);
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }

            return false;
        }
    }
}