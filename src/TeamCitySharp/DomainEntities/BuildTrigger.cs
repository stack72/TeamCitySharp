namespace TeamCitySharp.DomainEntities
{
    public class BuildTrigger
    {
        public override string ToString()
        {
            return "trigger";
        }

        public string Id { get; set; }

        public string Type { get; set; }

        public Properties Properties { get; set; }
    }
}