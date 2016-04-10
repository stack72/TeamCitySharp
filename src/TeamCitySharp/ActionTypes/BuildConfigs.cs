﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Xml;
using EasyHttp.Http;
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

        public BuildConfig CreateConfiguration(ProjectLocator projectLocator, string configurationName)
        {
            return _caller.PostFormat<BuildConfig>(configurationName, HttpContentTypes.TextPlain, HttpContentTypes.ApplicationJson, "/app/rest/projects/{0}/buildTypes", projectLocator);
        }

        public void AttachToTemplate(BuildTypeLocator buildTypeLocator, string buildTemplateId)
        {
            _caller.PutFormat(buildTemplateId, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/template", buildTypeLocator);
        }

        public void SetConfigurationSetting(BuildTypeLocator locator, string settingName, string settingValue)
        {
            _caller.PutFormat(settingValue, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/settings/{1}", locator, settingName);
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

            StringWriter sw = new StringWriter();
            using(XmlTextWriter writer = new XmlTextWriter(sw))
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
            _caller.GetDownloadFormat(downloadHandler, "/app/rest/buildTypes/{0}", locator);
        }

        public BuildConfig CopyBuildConfiguration(BuildTypeLocator buildTypeLocator, ProjectLocator destinationProjectLocator, string newConfigurationName)
        {
            var data = string.Format(@"<newBuildTypeDescription name='{0}' sourceBuildTypeLocator='{1}' copyAllAssociatedSettings='true' shareVCSRoots='false'/>", newConfigurationName, buildTypeLocator);

            return _caller.PostFormat<BuildConfig>(data, HttpContentTypes.ApplicationXml, HttpContentTypes.ApplicationJson, "/app/rest/projects/{0}/buildTypes", destinationProjectLocator);
        }

        public void TriggerBuildConfiguration(string buildConfigId)
        {
            var data = CreateTriggerBody(buildConfigId, null, new Property[0]);

            _caller.PostFormat(data, HttpContentTypes.ApplicationXml, "/app/rest/buildQueue");
        }

        public void TriggerBuildConfiguration(string buildConfigId, Property[] properties)
        {
            var triggerBody = CreateTriggerBody(buildConfigId, null, properties);

            _caller.PostFormat(triggerBody, HttpContentTypes.ApplicationXml, "/app/rest/buildQueue");
        }

        public void TriggerBuildConfiguration(string buildConfigId, int agentId, Property[] properties)
        {
            var bodyBuilder = CreateTriggerBody(buildConfigId, agentId, properties);

            _caller.PostFormat(bodyBuilder, HttpContentTypes.ApplicationXml, "/app/rest/buildQueue");
        }

        private static string CreateTriggerBody(string buildConfigId, int? agentId, Property[] properties)
        {
            var bodyBuilder = new StringBuilder();
            bodyBuilder.Append(@"<build>").AppendLine()
                .AppendFormat(@"<buildType id=""{0}""/>", buildConfigId).AppendLine();

            if (agentId.HasValue)
            {
                bodyBuilder.AppendFormat(@"<agent id=""{0}""/>", agentId).AppendLine();
            }

            if (properties.Any())
            {
                bodyBuilder.Append(@"<properties>").AppendLine();

                foreach (var property in properties)
                {
                    bodyBuilder.AppendFormat(@"<property name=""{0}"" value=""{1}""/>", property.Name, property.Value).AppendLine();
                }

                bodyBuilder.Append(@"</properties>").AppendLine();
            }

            bodyBuilder.Append("</build>").AppendLine();

            return bodyBuilder.ToString();
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

        public void UpdateName(BuildTypeLocator buildTypeLocator, string newName)
        {
            _caller.PutFormat(newName, HttpContentTypes.TextPlain, "/app/rest/buildTypes/{0}/name", buildTypeLocator);
        }
    }
}