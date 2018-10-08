using JsonFx.Json;

namespace TeamCitySharp.DomainEntities
{
    public class File
    {
        [JsonName("before-revision")] 
        public string BeforeRevision { get; set; }
        [JsonName("after-revision")] 
        public string AfterRevision { get; set; }
        [JsonName("relative-file")] 
        public string RelativeFile { get; set; }

        public string file { get; set; }
    }
}