namespace TeamCitySharp.DomainEntities
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string Href { get; set; }
        public string Email { get; set; }

        public RoleWrapper Roles { get; set; }
        public UserGroupWrapper Groups { get; set; } 

        public override string ToString()
        {
            return Username;
        }
    }
}