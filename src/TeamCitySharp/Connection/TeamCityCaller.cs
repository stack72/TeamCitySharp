using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
using EasyHttp.Http;
using EasyHttp.Infrastructure;
using TeamCitySharp.DomainEntities;
using File = System.IO.File;

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
                CreateHttpRequest(_configuration.UserName, _configuration.Password).GetAsFile(url, tempFileName);
                downloadHandler.Invoke(tempFileName);
                
            }finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }
        }

        public T GetFormat<T>(string urlPart, params object[] parts)
        {
            return Get<T>(string.Format(urlPart, parts));
        }

        public T PostFormat<T>(object data, string urlPart, params object[] parts)
        {
            return Post<T>(data.ToString(), string.Format(urlPart, parts));
        }

        public void PostFormat(object data, string urlPart, params object[] parts)
        {
            Post(data.ToString(), string.Format(urlPart, parts));
        }

        public void PutFormat(object data, string urlPart, params object[] parts)
        {
            Put(data.ToString(), string.Format(urlPart, parts));
        }

        public void DeleteFormat(string urlPart, params object[] parts)
        {
            Delete(string.Format(urlPart, parts));
        }

        private string GetUrl(string urlPart)
        {
            if (string.IsNullOrEmpty(urlPart))
                throw new ArgumentException("Url must be specfied");
            
            return CreateUrl(urlPart);
        }

        private HttpClient GetRequest()
        {
            if (CheckForUserNameAndPassword())
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");
            
            var request = CreateHttpRequest(_configuration.UserName, _configuration.Password);
            return request;
        }

        private bool CheckForUserNameAndPassword()
        {
            return !_configuration.ActAsGuest && string.IsNullOrEmpty(_configuration.UserName) && string.IsNullOrEmpty(_configuration.Password);
        }


        private void ProcessError(HttpResponse response, string url)
        {
            if (IsHttpError(response))
            {
                throw new HttpException(response.StatusCode, string.Format("Error {0}: Thrown with URL {1}", response.StatusDescription, url));
            }
        }

        public T Get<T>(string urlPart)
        {
            var request = GetRequest();
            var url = GetUrl(urlPart);
            var response = request.Get(url);
            ProcessError(response, url);
            return response.StaticBody<T>();
        }

        public void Put(string data, string urlPart)
        {
            var request = GetRequest();
            request.Request.Accept = HttpContentTypes.TextPlain;
            var url = GetUrl(urlPart);
            var response = request.Put(url, data, GetContentType(data));
            ProcessError(response, url);
        }

        public T Post<T>(string data, string urlPart)
        {
            return PostInternal(data, urlPart).StaticBody<T>();
        }

        public void Post(string data, string urlPart)
        {
            PostInternal(data, urlPart);
        }

        private HttpResponse PostInternal(string data, string urlPart)
        {
            var request = GetRequest();
            var url = GetUrl(urlPart);
            var response = request.Post(url, data, GetContentType(data));
            ProcessError(response, url);
            return response;
        }

        public void Delete(string urlPart)
        {
            var request = GetRequest();
            request.Request.Accept = HttpContentTypes.TextPlain;
            var url = GetUrl(urlPart);
            var response = request.Delete(url);
            ProcessError(response, url);
        }

        private string GetContentType(string data)
        {
            if (data.StartsWith("<"))
                return HttpContentTypes.ApplicationXml;
            return HttpContentTypes.TextPlain;
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

        HttpClient CreateHttpRequest(string userName, string password)
        {
            var httpClient = new HttpClient(new TeamcityJsonEncoderDecoderConfiguration());
            httpClient.Request.Accept = HttpContentTypes.ApplicationJson;
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
                var httpClient = CreateHttpRequest(_configuration.UserName, _configuration.Password);
                httpClient.Request.Accept = HttpContentTypes.TextPlain;
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
    }
}
