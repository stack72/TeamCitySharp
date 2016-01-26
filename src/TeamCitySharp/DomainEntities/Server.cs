using System;

namespace TeamCitySharp.DomainEntities
{
  public class Server
  {
    public string VersonMajor { get; set; }
    public string Version { get; set; }
    public string BuildNumber { get; set; }
    public DateTime CurrentTime { get; set; }
    public DateTime StartTime { get; set; }
  }
}