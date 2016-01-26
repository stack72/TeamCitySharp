using System.Collections.Generic;
using TeamCitySharp.DomainEntities;

namespace TeamCitySharp.ActionTypes
{
  public interface IAgents
  {
    List<Agent> All(bool includeDisconnected = false, bool includeUnauthorized = false);
    Agents GetFields(string fields);
  }
}