namespace TeamCitySharp.Connection
{
  internal interface IClientConnection
  {
    void Connect(string userName, string password);
    void ConnectAsGuest();
  }
}