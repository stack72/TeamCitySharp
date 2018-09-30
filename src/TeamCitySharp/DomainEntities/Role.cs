namespace TeamCitySharp.DomainEntities
{
    public class Role
    {
        public const string ProjectAdministrator = "PROJECT_ADMIN";
        public const string ProjectDeveloper = "PROJECT_DEVELOPER";

        public string Href { get; set; }
        public string Scope { get; set; }
        public string RoleId { get; set; }

        public override string ToString()
        {
            return RoleId;
        }
    }
}