using System;

namespace TeamCitySharp.DomainEntities
{
  public class Triggered
  {
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public BuildConfig BuildType { get; set; }
    public string Details { get; set;  }
    public User User { get; set; }
  }
}
