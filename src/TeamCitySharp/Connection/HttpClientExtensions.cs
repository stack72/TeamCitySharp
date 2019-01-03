using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace TeamCitySharp.Connection
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage Get(this HttpClient src, string url)
        {
            return src.GetAsync(url).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage Post(this HttpClient src, string url, object body, string contentType)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.ASCII, contentType);
            return src.PostAsync(url, content).GetAwaiter().GetResult();
        }
        
        public static HttpResponseMessage Put(this HttpClient src, string url, object body, string contentType)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.ASCII, contentType);
            return src.PutAsync(url, content).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage Delete(this HttpClient src, string url)
        {
            return src.DeleteAsync(url).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage GetAsFile(this HttpClient src, string url, string tempFilename)
        {
            var response = Get(src, url);
            var content = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
            File.WriteAllBytes(tempFilename, content);
            return response;
        }
    }
}