namespace TeamCitySharp.DomainEntities
{
  public class Credentials
  {
    public string HostName { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public bool UseSSL { get; set; }
    public bool ActAsGuest { get; set; }
  }
}