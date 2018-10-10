using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;

namespace TeamCitySharp.Connection
{
    public static class HttpResponseMessageExtensions
    {
        public static string RawText(this HttpResponseMessage src)
        {
            return src.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        public static T StaticBody<T>(this HttpResponseMessage src)
        {
            var stringContent = src.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return FromJson<T>(stringContent);
        }

        public static T FromJson<T>(this string src)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                DateFormatString = "yyyyMMdd'T'HHmmssK",
                Culture = CultureInfo.CurrentCulture
            };

            return JsonConvert.DeserializeObject<T>(src, jsonSerializerSettings);
        }
    }
}