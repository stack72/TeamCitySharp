using Newtonsoft.Json;

namespace TeamCitySharpAPI.Utilities
{
    public static class Deserialise
    {
        public static T DeserializeFromJson<T>(string json)
        {
            T deserializedProduct = JsonConvert.DeserializeObject<T>(json);
            return deserializedProduct;
        }
    }
}
