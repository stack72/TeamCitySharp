using System;
using System.Collections.Generic;

namespace TeamCitySharp.Util
{
    using System.IO;
    using System.Xml;

    internal class XmlUtil
    {
        public static string SingleElementDocument(string elementName, IDictionary<string, string> attributes)
        {
            var stringWriter = new StringWriter();

            using (var writer = new XmlTextWriter(stringWriter))
            {
                writer.WriteStartElement(elementName);
                
                foreach (var attribute in attributes)
                {
                    if (string.IsNullOrEmpty(attribute.Value))
                    {
                        throw new ArgumentNullException(attribute.Key);
                    }

                    writer.WriteAttributeString(attribute.Key, attribute.Value);
                }
                
                writer.WriteEndElement();
            }

            return stringWriter.ToString();
        }
    }
}
