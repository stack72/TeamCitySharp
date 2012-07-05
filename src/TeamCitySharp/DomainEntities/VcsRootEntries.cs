using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamCitySharp.DomainEntities
{
    public class VcsRootEntries
    {
        public override string ToString()
        {
            return "vcs-root-entries";
        }

        public List<VcsRootEntry> VcsRootEntry { get; set; }
    }
}
