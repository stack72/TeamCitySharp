

using System.Diagnostics;
using NUnit.Framework;

namespace TeamCitySharp.ActionTypes
{
    [TestFixture]
    public class AgentPoolTest
    {
        private TeamCityClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new TeamCityClient("amcon-tmcityp1.netadds.net:80");
            _client.Connect("friedrich.brunzema", "");
        }

        [Test]
        public void ListPools()
        {
            
            var pools = _client.AgentPools.All();
            foreach (var pool in pools)
            {
                Debug.WriteLine(pool.Name + " Id:" + pool.Id);
            }
            Assert.That(pools.Count, Is.GreaterThan(10));
        }

        [Test]
        public void AgentsByAgentPoolId()
        {
            var agents = _client.AgentPools.AgentsByAgentPoolId("23");
            foreach (var agent in agents)
            {
                Debug.WriteLine(agent.Name + " Id:" + agent.Id);
            }
            Assert.That(agents.Count, Is.GreaterThan(0));
        }

        [Test]
        public void ProjectsByAgentPoolId()
        {
            var projects = _client.AgentPools.ProjectsByAgentPoolId("23");
            foreach (var project in projects)
            {
                Debug.WriteLine(project.Name + " Id:" + project.Id + " ParentProjId:" + project.ParentProjectId);
            }
            Assert.That(projects.Count, Is.GreaterThan(0));
        }
    }
}