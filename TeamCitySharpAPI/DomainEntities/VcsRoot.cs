namespace TeamCitySharpAPI.DomainEntities
{
    public class VcsRoot
    {
        public string Href { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}