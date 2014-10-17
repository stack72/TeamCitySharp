using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class BuildTriggers
    {
        public override string ToString()
        {
            return "triggers";
        }

        public List<BuildTrigger> Trigger { get; set; }

        public string GetAsXml()
        {
            if (Trigger == null)
                return "<triggers/>";
            string result = string.Empty;
            result += "<triggers count=\"" + Trigger.Count + "\">";
            foreach (var item in Trigger)
            {
                result += "<trigger id=\"" + item.Id + "\" type=\"" + item.Type + "\">";
                result += item.Properties.GetAsXml();
                result += "</trigger>";
            }
            result += "</triggers>";
            return result;
        }
    }
}