namespace TeamCitySharpAPI.DomainEntities
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Href { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}