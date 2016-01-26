using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  public class SourceBuildType
  {
    public override string ToString()
    {
      return Id;
    }

    [DataMember(Name = "id")]
    public string Id { get; set; }
  }
}