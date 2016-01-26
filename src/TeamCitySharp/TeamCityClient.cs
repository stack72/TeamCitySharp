using TeamCitySharp.ActionTypes;
using TeamCitySharp.Connection;

namespace TeamCitySharp
{
  public class TeamCityClient : IClientConnection, ITeamCityClient
  {
    private readonly ITeamCityCaller _caller;
    private IBuilds _builds;
    private IProjects _projects;
    private IBuildConfigs _buildConfigs;
    private IServerInformation _serverInformation;
    private IUsers _users;
    private IAgents _agents;
    private IVcsRoots _vcsRoots;
    private IChanges _changes;
    private IBuildArtifacts _artifacts;
    private IBuildInvestigations _investigations;
    private IStatistics _statistics;

    public TeamCityClient(string hostName, bool useSsl = false)
    {
      _caller = new TeamCityCaller(hostName, useSsl);
    }

    public void Connect(string userName, string password)
    {
      _caller.Connect(userName, password, false);
    }

    public void EnableCache()
    {
      _caller.EnableCache();
    }

    public void DisableCache()
    {
      _caller.DisableCache();
    }

    public void ConnectAsGuest()
    {
      _caller.Connect(string.Empty, string.Empty, true);
    }

    public bool Authenticate(bool throwExceptionOnHttpError = true)
    {
      return _caller.Authenticate("/app/rest", throwExceptionOnHttpError);
    }

    public IBuilds Builds
    {
      get { return _builds ?? (_builds = new Builds(_caller)); }
    }

    public IBuildConfigs BuildConfigs
    {
      get { return _buildConfigs ?? (_buildConfigs = new BuildConfigs(_caller)); }
    }

    public IProjects Projects
    {
      get { return _projects ?? (_projects = new Projects(_caller)); }
    }

    public IServerInformation ServerInformation
    {
      get { return _serverInformation ?? (_serverInformation = new ServerInformation(_caller)); }
    }

    public IUsers Users
    {
      get { return _users ?? (_users = new Users(_caller)); }
    }

    public IAgents Agents
    {
      get { return _agents ?? (_agents = new Agents(_caller)); }
    }

    public IVcsRoots VcsRoots
    {
      get { return _vcsRoots ?? (_vcsRoots = new VcsRoots(_caller)); }
    }

    public IChanges Changes
    {
      get { return _changes ?? (_changes = new Changes(_caller)); }
    }

    public IBuildArtifacts Artifacts
    {
      get { return _artifacts ?? (_artifacts = new BuildArtifacts(_caller)); }
    }

    public IBuildInvestigations Investigations
    {
      get { return _investigations ?? (_investigations = new BuildInvestigations(_caller)); }
    }

    public IStatistics Statistics
    {
      get { return _statistics ?? (_statistics = new Statistics(_caller)); }
    }
  }
}