using System;
using System.Runtime.Serialization;

namespace TeamCitySharp.DomainEntities
{
  [DataContract]
  public class VcsRoot
  {
    [DataMember(Name = "id")]
    public string Id { get; set; }

    [DataMember(Name = "vcs-root-id")]
    public string VcsRootId { get; set; }

    [DataMember(Name = "vcsName")]
    public string VcsName { get; set; }

    [DataMember(Name = "href")]
    public string Href { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "version")]
    public string Version { get; set; }

    [DataMember(Name = "status")]
    public string Status { get; set; }

    [DataMember(Name = "lastChecked")]
    public DateTime LastChecked { get; set; }

    [DataMember(Name = "lastVersion")]
    public string LastVersion { get; set; }

    [DataMember]
    public Properties Properties { get; set; }

    public override string ToString()
    {
      return Name;
    }

   
  }
}