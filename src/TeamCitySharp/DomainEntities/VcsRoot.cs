using System;
using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  [DataContract]
  public class VcsRoot
  {
    [DataMember(Name = "id")]
    [JsonFx.Json.JsonName("id")]
    public string Id { get; set; }

    [DataMember(Name = "vcs-root-id")]
    [JsonFx.Json.JsonName("vcs-root-id")]
    public string VcsRootId { get; set; }

    [DataMember(Name = "vcsName")]
    [JsonFx.Json.JsonName("vcsName")]
    public string VcsName { get; set; }

    [DataMember(Name = "href")]
    [JsonFx.Json.JsonName("href")]
    public string Href { get; set; }

    [DataMember(Name = "name")]
    [JsonFx.Json.JsonName("name")]
    public string Name { get; set; }

    [DataMember(Name = "version")]
    [JsonFx.Json.JsonName("version")]
    public string Version { get; set; }

    [DataMember(Name = "status")]
    [JsonFx.Json.JsonName("status")]
    public string Status { get; set; }

    [DataMember(Name = "lastChecked")]
    [JsonFx.Json.JsonName("lastChecked")]
    public DateTime LastChecked { get; set; }

    [DataMember(Name = "lastVersion")]
    [JsonFx.Json.JsonName("lastVersion")]
    public string LastVersion { get; set; }


    [DataMember]
    [JsonFx.Json.JsonName("project")]
    public Project Project { get; set; }

    [DataMember]
    [JsonFx.Json.JsonName("properties")]
    public Properties Properties { get; set; }

    public override string ToString()
    {
      return Name;
    }

   
  }
}