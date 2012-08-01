using System;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Web;
using EasyHttp.Http;
using TeamCitySharp.DomainEntities;
using File = System.IO.File;
using HttpException = EasyHttp.Infrastructure.HttpException;
using HttpResponse = EasyHttp.Http.HttpResponse;

namespace TeamCitySharp.Connection
{
    internal class TeamCityCaller
    {
        private readonly Credentials _configuration = new Credentials();

        public TeamCityCaller(string hostName, bool useSsl)
        {
            if (string.IsNullOrEmpty(hostName))
                throw new ArgumentNullException("hostName");

            _configuration.UseSSL = useSsl;
            _configuration.HostName = hostName;
        }

        public void Connect(string userName, string password, bool actAsGuest)
        {
            _configuration.Password = password;
            _configuration.UserName = userName;
            _configuration.ActAsGuest = actAsGuest;
        }

        public void GetDownloadFormat(Action<string> downloadHandler, string urlPart, params object[] parts)
        {
            if (CheckForUserNameAndPassword())
            {
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");
            }

            if (string.IsNullOrEmpty(urlPart))
            {
                throw new ArgumentException("Url must be specfied");
            }

            if(downloadHandler == null)
            {
                throw new ArgumentException("A download handler must be specfied.");
            }

            string tempFileName = Path.GetRandomFileName();
            var url = CreateUrl(string.Format(urlPart,parts));

            try
            {
                CreateHttpRequest(_configuration.UserName, _configuration.Password, HttpContentTypes.ApplicationJson).GetAsFile(url, tempFileName);
                downloadHandler.Invoke(tempFileName);
                
            }finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }
        }

        public Uri GetDownloadFormat(string uriPart)
        {
          var uri = new Uri(CreateUrl(uriPart));
          return uri;
        }

        public T GetFormat<T>(string urlPart, params object[] parts)
        {
            return Get<T>(string.Format(urlPart, parts));
        }

        public bool StartBackup(string urlPart)
        {
            if (CheckForUserNameAndPassword())
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

            if (string.IsNullOrEmpty(urlPart))
                throw new ArgumentException("Url must be specfied");

            var url = CreateUrl(urlPart);

            var httpClient = CreateHttpRequest(_configuration.UserName, _configuration.Password, HttpContentTypes.TextPlain);
            var response = httpClient.Post(url, null, HttpContentTypes.TextPlain);
            if (IsHttpError(response))
            {
                throw new HttpException(response.StatusCode, string.Format("Error {0}: Thrown with URL {1}", response.StatusDescription, url));
            }

            return response.StatusCode == HttpStatusCode.OK;
        }

        

        public T Get<T>(string urlPart)
        {
            if (CheckForUserNameAndPassword())
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

            if (string.IsNullOrEmpty(urlPart))
                throw new ArgumentException("Url must be specfied");

            var url = CreateUrl(urlPart);

            var response = CreateHttpRequest(_configuration.UserName, _configuration.Password, HttpContentTypes.ApplicationJson).Get(url);
            if (IsHttpError(response))
            {
                throw new HttpException(response.StatusCode, string.Format("Error {0}: Thrown with URL {1}", response.StatusDescription, url));
            }

            return response.StaticBody<T>();
        }

        private bool CheckForUserNameAndPassword()
        {
            return !_configuration.ActAsGuest && string.IsNullOrEmpty(_configuration.UserName) && string.IsNullOrEmpty(_configuration.Password);
        }

        private bool IsHttpError(HttpResponse response)
        {
            var num = (int) response.StatusCode / 100;

            return (num == 4 || num == 5);
        }

        private string CreateUrl(string urlPart)
        {
            var protocol = _configuration.UseSSL ? "https://" : "http://";
            var authType = _configuration.ActAsGuest ? "/guestAuth" : "/httpAuth";

            return string.Format("{0}{1}{2}{3}", protocol, _configuration.HostName, authType, urlPart);
        }

        HttpClient CreateHttpRequest(string userName, string password, string accept)
        {
            var httpClient = new HttpClient(new TeamcityJsonEncoderDecoderConfiguration());
            httpClient.Request.Accept = accept;
            if (!_configuration.ActAsGuest)
            {
                httpClient.Request.SetBasicAuthentication(userName, password);
                httpClient.Request.ForceBasicAuth = true;
            }

            return httpClient;
        }

        public bool Authenticate(string urlPart)
        {
            try
            {
                var httpClient = CreateHttpRequest(_configuration.UserName, _configuration.Password, HttpContentTypes.TextPlain);
                httpClient.ThrowExceptionOnHttpError = true;
                httpClient.Get(CreateUrl(urlPart));

                var response = httpClient.Response;
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (HttpException exception)
            {
                throw new AuthenticationException(exception.StatusDescription);
            }
        }

      /// <summary>
        ///   Creates a <see cref = "WebRequest" /> for the specified <paramref name = "uri" /> with
        ///   the credentials of the TeamCity Account
        /// </summary>
        /// <param name = "uri">The Uri for the <see cref = "WebRequest" /></param>
        /// <returns>A <see cref = "WebRequest" /> that can access the TeamCity Server</returns>
        private HttpWebRequest CreateWebRequest(Uri uri)
        {
          var webRequest = (HttpWebRequest)WebRequest.Create(uri);
          webRequest.Credentials = new NetworkCredential(_configuration.UserName,
                                                         _configuration.Password);
          webRequest.Proxy = null;
          return (webRequest);
        }

        /// <summary>
        ///   Downloads a Resource from the TeamCity Server and saves it to <paramref name = "destinationFile" />
        /// </summary>
        /// <param name = "uri">The Uri of the Resource</param>
        /// <param name = "destinationFile">The destination File</param>
        internal void Download(Uri uri, string destinationFile)
        {
          HttpWebRequest webRequest = CreateWebRequest(uri);

          using (WebResponse webResponse = webRequest.GetResponse())
          {
            using (Stream sourceStream = webResponse.GetResponseStream())
            {
              using (FileStream fs = new FileStream(destinationFile,
                                                    FileMode.OpenOrCreate,
                                                    FileAccess.ReadWrite,
                                                    FileShare.None))
              {
                byte[] buffer = new byte[4096 * 4];
                int count;

                do
                {
                  count = sourceStream.Read(buffer,
                                            0,
                                            buffer.Length);
                  fs.Write(buffer,
                           0,
                           count);
                } while (count > 0);
              }
            }
          }
        }

    }
}