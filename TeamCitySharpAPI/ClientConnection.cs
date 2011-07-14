namespace TeamCitySharpAPI
{
    public interface ClientConnection
    {
        void Connect(string userName, string password, bool actAsGuest = false);
    }
}