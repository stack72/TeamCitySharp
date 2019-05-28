using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using TeamCitySharp.DomainEntities;
using File = System.IO.File;

namespace TeamCitySharp.Connection
{
  internal class TeamCityCaller : ITeamCityCaller
  {
    private readonly Credentials m_credentials;
    private bool m_useNoCache;
    private string m_version="";

    public TeamCityCaller(string hostName, bool useSsl)
    {
      if (string.IsNullOrEmpty(hostName))
        throw new ArgumentNullException("hostName");

      m_credentials = new Credentials {UseSSL = useSsl, HostName = hostName};
    }

    public void DisableCache()
    {
      m_useNoCache = true;
    }

    public void UseVersion(string version)
    {
      m_version = version;
    }

    public void EnableCache()
    {
      m_useNoCache = false;
    }

    public void Connect(string userName, string password, bool actAsGuest)
    {
      m_credentials.Password = password;
      m_credentials.UserName = userName;
      m_credentials.ActAsGuest = actAsGuest;
    }

    public T GetFormat<T>(string urlPart, params object[] parts)
    {
      return Get<T>(string.Format(urlPart, parts));
    }

    public void GetFormat(string urlPart, params object[] parts)
    {
      Get(string.Format(urlPart, parts));
    }

    public T PostFormat<T>(object data, string contentType, string accept, string urlPart, params object[] parts)
    {
      return Post<T>(data, contentType, string.Format(urlPart, parts), accept);
    }

    public void PostFormat(object data, string contentType, string urlPart, params object[] parts)
    {
      Post(data, contentType, string.Format(urlPart, parts), string.Empty);
    }

    public void PutFormat(object data, string contentType, string urlPart, params object[] parts)
    {
      Put(data, contentType, string.Format(urlPart, parts), string.Empty);
    }

    public void DeleteFormat(string urlPart, params object[] parts)
    {
      Delete(string.Format(urlPart, parts));
    }

    public void GetDownloadFormat(Action<string> downloadHandler, string urlPart, params object[] parts)
    {
      if (CheckForUserNameAndPassword())
        throw new ArgumentException("If you are not acting as a guest you must supply userName and password");
      if (string.IsNullOrEmpty(urlPart))
        throw new ArgumentException("Url must be specified");

      if (downloadHandler == null)
        throw new ArgumentException("A download handler must be specified.");

      string tempFileName = Path.GetRandomFileName();
      var url = CreateUrl(string.Format(urlPart, parts));

      try
      {
        CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.ApplicationJson)
          .GetAsFile(url, tempFileName);
        downloadHandler.Invoke(tempFileName);
      }
      finally
      {
        if (File.Exists(tempFileName))
          File.Delete(tempFileName);
      }
    }

    public string StartBackup(string urlPart)
    {
      if (CheckForUserNameAndPassword())
        throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

      if (string.IsNullOrEmpty(urlPart))
        throw new ArgumentException("Url must be specified");

      var url = CreateUrl(urlPart);

      var httpClient = CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.TextPlain);
      var response = httpClient.Post(url, null, HttpContentTypes.TextPlain);
      ThrowIfHttpError(response, url);

      if (response.StatusCode == HttpStatusCode.OK)
        return response.RawText();

      return string.Empty;
    }

    public T Get<T>(string urlPart)
    {
      var response = GetResponse(urlPart);
      return response.StaticBody<T>();
    }

    public void Get(string urlPart)
    {
      GetResponse(urlPart);
    }

    private HttpResponseMessage GetResponse(string urlPart)
    {
      if (CheckForUserNameAndPassword())
        throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

      if (string.IsNullOrEmpty(urlPart))
        throw new ArgumentException("Url must be specified");

      var url = CreateUrl(urlPart);

      var response =
        CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.ApplicationJson).Get(url);
      ThrowIfHttpError(response, url);
      return response;
    }

    public T Post<T>(object data, string contentType, string urlPart, string accept)
    {
      return Post(data, contentType, urlPart, accept).StaticBody<T>();
    }

    public bool Authenticate(string urlPart, bool throwExceptionOnHttpError = true)
    {
      try
      {
        var httpClient = CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.TextPlain);
        var response = httpClient.Get(CreateUrl(urlPart));
        if (response.StatusCode != HttpStatusCode.OK && throwExceptionOnHttpError)
        {
            throw new AuthenticationException();
        }

        return response.StatusCode == HttpStatusCode.OK;
      }
      catch (HttpException exception)
      {
        throw new AuthenticationException(exception.StatusDescription);
      }
    }

    public HttpResponseMessage Post(object data, string contentType, string urlPart, string accept)
    {
      var response = MakePostRequest(data, contentType, urlPart, accept);

      return response;
    }

    public HttpResponseMessage Put(object data, string contentType, string urlPart, string accept)
    {
      var response = MakePutRequest(data, contentType, urlPart, accept);

      return response;
    }

    public void Delete(string urlPart)
    {
      MakeDeleteRequest(urlPart);
    }

    private void MakeDeleteRequest(string urlPart)
    {
      var client = CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.TextPlain);
      var url = CreateUrl(urlPart);
      var response = client.Delete(url);
      ThrowIfHttpError(response, url);
    }

    private HttpResponseMessage MakePostRequest(object data, string contentType, string urlPart, string accept)
    {
      var client = CreateHttpClient(m_credentials.UserName, m_credentials.Password,
                                    string.IsNullOrWhiteSpace(accept) ? GetContentType(data.ToString()) : accept);
     
      var url = CreateUrl(urlPart);
      var response = client.Post(url, data, contentType);
      ThrowIfHttpError(response, url);

      return response;
    }

    private HttpResponseMessage MakePutRequest(object data, string contentType, string urlPart, string accept)
    {
      var client = CreateHttpClient(m_credentials.UserName, m_credentials.Password,
                                    string.IsNullOrWhiteSpace(accept) ? GetContentType(data.ToString()) : accept);
      var url = CreateUrl(urlPart);
      var response = client.Put(url, data, contentType);
      ThrowIfHttpError(response, url);

      return response;
    }

    private static bool IsHttpError(HttpResponseMessage response)
    {
      var num = (int)response.StatusCode / 100;

      return (num == 4 || num == 5);
    }

    /// <summary>
    /// <para>If the <paramref name="response"/> is OK (see <see cref="IsHttpError"/> for definition), does nothing.</para>
    /// <para>Otherwise, throws an exception which includes also the response raw text.
    /// This would often contain a Java exception dump from the TeamCity REST Plugin, which reveals the cause of some cryptic cases otherwise showing just "Bad Request" in the HTTP error.
    /// Also this comes in handy when TeamCity goes into maintenance, and you get back the banner in HTML instead of your data.</para> 
    /// </summary>
    private static void ThrowIfHttpError(HttpResponseMessage response, string url)
    {
      if (!IsHttpError(response))
        return;
      throw new HttpException(response.StatusCode,
        $"Error: {response.ReasonPhrase}\nHTTP: {response.StatusCode}\nURL: {url}\n{response.RawText()}");
    }

    private string CreateUrl(string urlPart)
    {
      var protocol = m_credentials.UseSSL ? "https://" : "http://";
      if(m_credentials.UseSSL) ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
      var authType = m_credentials.ActAsGuest ? "/guestAuth" : "/httpAuth";
      var restUrl = "/app/rest";
      var version = m_version == "" ? "" : $"/{m_version}";
      var uri = $"{protocol}{m_credentials.HostName}{authType}{restUrl}{version}{urlPart}";
      return Uri.EscapeUriString(uri).Replace("+", "%2B");
    }

    private HttpClient CreateHttpClient(string userName, string password, string accept)
    {
      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept
          .Add(new MediaTypeWithQualityHeaderValue(accept));

      if (m_useNoCache)
        httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue{NoCache = true};
      if (!m_credentials.ActAsGuest)
      {
        var credentials = Encoding.ASCII.GetBytes($"{userName}:{password}");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
      }

      return httpClient;
    }

    // only used by the artifact listing methods since i havent found a way to deserialize them into a domain entity
    public string GetRaw(string urlPart)
    {
      if (CheckForUserNameAndPassword())
        throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

      if (string.IsNullOrEmpty(urlPart))
        throw new ArgumentException("Url must be specified");

      var url = CreateUrl(urlPart);

      var httpClient = CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.TextPlain);
      var response = httpClient.Get(url);
      if (IsHttpError(response))
      {
        throw new HttpException(response.StatusCode,
          $"Error {response.ReasonPhrase}: Thrown with URL {url}");
      }

      return response.RawText();
    }

    private bool CheckForUserNameAndPassword()
    {
      return !m_credentials.ActAsGuest && string.IsNullOrEmpty(m_credentials.UserName) &&
             string.IsNullOrEmpty(m_credentials.Password);
    }

    private string GetContentType(string data)
    {
      if (data.StartsWith("<"))
        return HttpContentTypes.ApplicationXml;
      return HttpContentTypes.TextPlain;
    }

    public bool GetBoolean(string urlPart, params object[] parts)
    {
      var urlFull = string.Format(urlPart, parts);

      try
      {
        if (CheckForUserNameAndPassword())
          throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

        if (string.IsNullOrEmpty(urlFull))
          throw new ArgumentException("Url must be specified");

        var url = CreateUrl(urlFull);

        var response =
          CreateHttpClient(m_credentials.UserName, m_credentials.Password, HttpContentTypes.ApplicationJson).Get(url);
        return !IsHttpError(response);
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}