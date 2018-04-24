using System.Collections.Generic;
using System.Web;

namespace TeamCitySharp.DomainEntities
{
    public class Properties
    {
        public override string ToString()
        {
            return "properties";
        }
        public List<Property> Property { get; set; }

        public string GetAsXml()
        {
            if (Property == null)
                return "<properties/>";
            string result = string.Empty;
            result += "<properties>";
            foreach (var property in Property)
            {
                result += "<property name=\"" + HttpUtility.HtmlEncode(property.Name) + "\" value=\"" + HttpUtility.HtmlEncode(property.Value) + "\"/>";
            }
            result += "</properties>";
            return result;
        }
    }
}