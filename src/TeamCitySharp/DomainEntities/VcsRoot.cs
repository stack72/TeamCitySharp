namespace TeamCitySharp.DomainEntities
{
    public class VcsRoot
    {
        public string Id { get; set; }
        public string vcsName { get; set; }
        public string Href { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public string lastChecked { get; set; }

        public override string ToString()
        {
            return vcsName;
        }
    }
}