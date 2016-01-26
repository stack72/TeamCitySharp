using TeamCitySharp.ActionTypes;

namespace TeamCitySharp
{
  public interface ITeamCityClient
  {
    void Connect(string userName, string password);
    void ConnectAsGuest();
    void DisableCache();
    void EnableCache();
    bool Authenticate(bool throwExceptionOnHttpError = true);

    IBuilds Builds { get; }
    IBuildConfigs BuildConfigs { get; }
    IProjects Projects { get; }
    IServerInformation ServerInformation { get; }
    IUsers Users { get; }
    IAgents Agents { get; }
    IVcsRoots VcsRoots { get; }
    IChanges Changes { get; }
    IBuildArtifacts Artifacts { get; }
    IStatistics Statistics { get; }
    IBuildInvestigations Investigations { get; }
  }
}