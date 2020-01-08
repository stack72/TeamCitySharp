using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;

namespace TeamCitySharp
{
  public class TeamCityClient : IClientConnection, ITeamCityClient
  {
    private readonly ITeamCityCaller m_caller;
    private IBuilds m_builds;
    private IBuildQueue m_buildQueue;
    private IProjects m_projects;
    private IBuildConfigs m_buildConfigs;
    private IServerInformation m_serverInformation;
    private IUsers m_users;
    private IAgents m_agents;
    private IVcsRoots m_vcsRoots;
    private IChanges m_changes;
    private IBuildArtifacts m_artifacts;
    private IBuildInvestigations m_investigations;
    private IStatistics m_statistics;
    private ITests m_tests;

    public TeamCityClient(string hostName, bool useSsl = false)
    {
      m_caller = new TeamCityCaller(hostName, useSsl);
    }

    public void Connect(string userName, string password)
    {
      m_caller.Connect(userName, password, false);
    }

    public void UseVersion(string version)
    {
      m_caller.UseVersion(version);
    }
    public void EnableCache()
    {
      m_caller.EnableCache();
    }

    public void DisableCache()
    {
      m_caller.DisableCache();
    }

    public void ConnectAsGuest()
    {
      m_caller.Connect(string.Empty, string.Empty, true);
    }

    public bool Authenticate(bool throwExceptionOnHttpError = true)
    {
      return m_caller.Authenticate("", throwExceptionOnHttpError);
    }

    public IBuilds Builds
    {
      get { return m_builds ?? (m_builds = new Builds(m_caller)); }
    }

    public IBuildQueue BuildQueue
    {
      get { return m_buildQueue ?? (m_buildQueue = new BuildQueue(m_caller)); }
    }

    public IBuildConfigs BuildConfigs
    {
      get { return m_buildConfigs ?? (m_buildConfigs = new BuildConfigs(m_caller)); }
    }

    public IProjects Projects
    {
      get { return m_projects ?? (m_projects = new Projects(m_caller)); }
    }

    public IServerInformation ServerInformation
    {
      get { return m_serverInformation ?? (m_serverInformation = new ServerInformation(m_caller)); }
    }

    public IUsers Users
    {
      get { return m_users ?? (m_users = new Users(m_caller)); }
    }

    public IAgents Agents
    {
      get { return m_agents ?? (m_agents = new Agents(m_caller)); }
    }

    public IVcsRoots VcsRoots
    {
      get { return m_vcsRoots ?? (m_vcsRoots = new VcsRoots(m_caller)); }
    }

    public IChanges Changes
    {
      get { return m_changes ?? (m_changes = new Changes(m_caller)); }
    }

    public IBuildArtifacts Artifacts
    {
      get { return m_artifacts ?? (m_artifacts = new BuildArtifacts(m_caller)); }
    }

    public IBuildInvestigations Investigations
    {
      get { return m_investigations ?? (m_investigations = new BuildInvestigations(m_caller)); }
    }

    public IStatistics Statistics
    {
      get { return m_statistics ?? (m_statistics = new Statistics(m_caller)); }
    }
    public ITests Tests
    {
        get { return m_tests ?? (m_tests = new Tests(m_caller)); }
    }

  }
}