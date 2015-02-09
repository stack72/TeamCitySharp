using System.Collections.Generic;

namespace TeamCitySharp.DomainEntities
{
    public class VcsRootEntries
    {
        public override string ToString()
        {
            return "vcs-root-entries";
        }

        public List<VcsRootEntry> VcsRootEntry { get; set; }

        public string GetAsXml()
        {
            if (VcsRootEntry == null)
                return "<vcs-root-entries/>";
            string result = string.Empty;
            result += "<vcs-root-entries count=\"" + VcsRootEntry.Count + "\">";
            foreach (var item in VcsRootEntry)
            {
                result += "<vcs-root-entry>";
                result += "<vcs-root-entry id=\"" + item.VcsRoot.Id + "\" name=\"" + item.VcsRoot.Name + "\" href=\"" + item.VcsRoot.Href + "\">";
                result += "<checkout-rules/>";
                result += "</vcs-root-entry>";
            }
            result += "</vcs-root-entries>";
            return result;
        }
    }
}