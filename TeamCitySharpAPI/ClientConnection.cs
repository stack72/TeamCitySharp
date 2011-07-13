namespace TeamCitySharpAPI
{
    public interface ClientConnection
    {
        void Connect(string userName, string password, bool useSsl = false, bool actAsGuest = false);
    }
}