using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
      StringContent content = null;
      if(body != null)
      {
          var data = contentType == HttpContentTypes.ApplicationJson ? JsonConvert.SerializeObject(body) : body.ToString();

          content = new StringContent(data, Encoding.ASCII, contentType);
      }
      return src.PostAsync(url, content).GetAwaiter().GetResult();
    }

    public static HttpResponseMessage Put(this HttpClient src, string url, object body, string contentType)
    {
      StringContent content = null;
      if(body != null)
      {
          var data = contentType == HttpContentTypes.ApplicationJson ? JsonConvert.SerializeObject(body) : body.ToString();

          content = new StringContent(data, Encoding.ASCII, contentType);
      }
      return src.PutAsync(url, content).GetAwaiter().GetResult();
    }

    public static HttpResponseMessage Delete(this HttpClient src, string url)
    {
      return src.DeleteAsync(url).GetAwaiter().GetResult();
    }

    public static HttpResponseMessage GetAsFile(this HttpClient src, string url, string tempFilename)
    {
      using (var response = src.Get(url))
      {
        response.EnsureSuccessStatusCode();

        using (Stream contentStream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult(),
          fileStream = new FileStream(tempFilename, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
        {
          var buffer = new byte[8192];
          var isMoreToRead = true;

          do
          {
            var read = contentStream.ReadAsync(buffer, 0, buffer.Length).GetAwaiter().GetResult();
            if (read == 0)
            {
              isMoreToRead = false;
            }
            else
            {
              fileStream.WriteAsync(buffer, 0, read).GetAwaiter().GetResult();
            }
          } while (isMoreToRead);

          return response;
        }
      }
    }
  }
}
