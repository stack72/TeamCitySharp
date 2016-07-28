using System;

namespace TeamCitySharp.DomainEntities
{
  public class Artifact
  {
      public ulong Size { get; set; }
      public DateTime ModificationTime { get; set; }
      public string Name { get; set; }
      public string Href { get; set; }
      public HrefWrapper Content { get; set; }
      public HrefWrapper Children { get; set; }

      public override string ToString()
      {
        return Name;
      }
  }
}
