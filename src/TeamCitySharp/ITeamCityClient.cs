using TeamCitySharp.ActionTypes;

namespace TeamCitySharp
{
    public interface ITeamCityClient
    {
        void Connect(string userName, string password, bool actAsGuest = false);
        bool Authenticate();

        IBuilds Builds { get; }
        IBuildDetails BuildDetails { get; }
        IBuildConfigs BuildConfigs { get; }
        IProjects Projects { get; }
        IServerInformation ServerInformation { get; }
        IUsers Users { get; }
        IAgents Agents { get; }
        IVcsRoots VcsRoots { get; }
        IChanges Changes { get; }
        IBuildArtifacts Artifacts { get; }
    }
}