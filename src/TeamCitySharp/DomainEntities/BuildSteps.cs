using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class BuildSteps
    {
        public override string ToString()
        {
            return "steps";
        }

        public List<BuildStep> Step { get; set; }

        public string GetAsXml()
        {
            if (Step == null)
                return "<steps/>";
            string result = string.Empty;
            result += "<steps count=\"" + Step.Count + "\">";
            foreach (var item in Step)
            {
                result += "<step id=\"" + item.Id + "\" name=\"" + item.Name + "\" type=\"" + item.Type + "\">";
                result += item.Properties.GetAsXml();
                result += "</step>";
            }
            result += "</steps>";
            return result;
        }
    }
}