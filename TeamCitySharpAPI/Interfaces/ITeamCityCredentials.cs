namespace TeamCitySharpAPI
{
    public interface ITeamCityCredentials
    {
        string HostName { get; }
        string Password { get; }
        string UserName { get; }
        bool UseSSL { get; }
    }
}