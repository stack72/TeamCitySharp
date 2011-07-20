using System.Collections.Generic;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public interface TeamCityChanges: ClientConnection
    {
        List<Change> GetAllChanges();
        Change GetChangeDetailsByChangeId(string id);
    }

    public class ChangeWrapper
    {
        public List<Change> Change { get; set; }
    }
}