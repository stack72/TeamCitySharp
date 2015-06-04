using JsonFx.Json;

namespace TeamCitySharp.DomainEntities
{
    public class File
    {
        [JsonName("relative-file")]
        public string RelativeFile { get; set; }
        [JsonName("before-revision")]
        public string BeforeRevision { get; set; }
        [JsonName("after-revision")]
        public string AfterRevision { get; set; }
        [JsonName("file")]
        public string BaseFile { get; set; }
    }
}