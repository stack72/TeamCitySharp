// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleBuildQueueUsage.cs" company="Hukano">
// Copyright (c) Hukano. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using NUnit.Framework;
using TeamCitySharp.Locators;

namespace TeamCitySharp.IntegrationTests
{
  [TestFixture]
  public class when_interacting_to_get_build_queue_info
  {
    private ITeamCityClient m_client;
    private readonly string m_server;
    private readonly bool m_useSsl;
    private readonly string m_username;
    private readonly string m_password;
    private readonly string m_queuedBuildConfigId;
    private readonly string m_queuedProjectId;


    public when_interacting_to_get_build_queue_info()
    {
      m_server = ConfigurationManager.AppSettings["Server"];
      bool.TryParse(ConfigurationManager.AppSettings["UseSsl"], out m_useSsl);
      m_username = ConfigurationManager.AppSettings["Username"];
      m_password = ConfigurationManager.AppSettings["Password"];
      m_queuedBuildConfigId = ConfigurationManager.AppSettings["QueuedBuildConfigId"];
      m_queuedProjectId = ConfigurationManager.AppSettings["QueuedProjectId"];
    }

    [SetUp]
    public void SetUp()
    {
      m_client = new TeamCityClient(m_server, m_useSsl);
      m_client.Connect(m_username, m_password);
    }

    [Test]
    public void it_returns_the_builds_queued_by_build_config_id()
    {
      var result = m_client.BuildQueue.ByBuildTypeLocator(BuildTypeLocator.WithId(m_queuedBuildConfigId));

      Assert.IsNotEmpty(result);
    }

    [Test]
    public void it_returns_the_builds_queued_by_project_id()
    {
      var result = m_client.BuildQueue.ByProjectLocater(ProjectLocator.WithId(m_queuedProjectId));

      Assert.IsNotEmpty(result);
    }
  }
}