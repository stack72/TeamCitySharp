using System.Text.RegularExpressions;

namespace TeamCitySharp.DomainEntities
{
    public class TestOccurrence
    {
        public int Duration { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public Test Test { get; set; }
    }

    public class Test
    {
        private static readonly Regex IdRegex = new Regex(@"^\/httpAuth\/app\/rest/tests\/id\:(?<id>\-?\d+)$", RegexOptions.Compiled);

        public string Id
        {
            get
            {
                return IdRegex.Match(Href).Groups["id"].Value;
            }
        }

        public string Name { get; set; }
        public string Href { get; set; }
    }
}