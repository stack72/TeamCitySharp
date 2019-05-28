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
        //TODO: quick fix, need to fix soon for a big transaction
        src.Timeout=TimeSpan.FromHours(1);
        var content = src.GetAsync(url);
        return content.GetAwaiter().GetResult();    
    }

    public static HttpResponseMessage Post(this HttpClient src, string url, object body, string contentType)
    {
      var data = contentType == HttpContentTypes.ApplicationJson ? JsonConvert.SerializeObject(body) : body.ToString();

      var content = new StringContent(data, Encoding.ASCII, contentType);
      return src.PostAsync(url, content).GetAwaiter().GetResult();
    }

    public static HttpResponseMessage Put(this HttpClient src, string url, object body, string contentType)
    {
      var data = contentType == HttpContentTypes.ApplicationJson ? JsonConvert.SerializeObject(body) : body.ToString();

      var content = new StringContent(data, Encoding.ASCII, contentType);
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