using System.Collections.Generic;
using System.Web;

namespace TeamCitySharp.DomainEntities
{
    public class AgentRequirements
    {
        public override string ToString()
        {
            return "agent-requirements";
        }

        public List<AgentRequirement> AgentRequirement { get; set; }

        public string GetAsXml()
        {
            if (AgentRequirement == null)
                return "<agent-requirements/>";
            string result = string.Empty;
            result += "<agent-requirements>";
            foreach (var item in AgentRequirement)
            {
                result += "<agent_requirement id=\"" + item.Id + "\" type=\"" + item.Type + "\">";
                result += item.Properties.GetAsXml();
                result += "</agent_requirement>";
            }
            result += "</agent-requirements>";
            return result;
        }
    }
}