using System;
using EasyHttp.Http;
using EasyHttp.Infrastructure;
using TeamCitySharp.DomainEntities;

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

        public T GetFormat<T>(string urlPart, params object[] parts)
        {
            return Get<T>(string.Format(urlPart, parts));
        }

        public T Get<T>(string urlPart)
        {
            if (CheckForUserNameAndPassword())
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

            if (string.IsNullOrEmpty(urlPart))
                throw new ArgumentException("UrlPart must be specfied");

            var request = CreateHttpRequest(_configuration.UserName, _configuration.Password);
            string url = CreateUrl(urlPart);

            var response = request.Get(url);
            if (IsHttpError(response))
            {
                throw new HttpException(response.StatusCode, response.StatusDescription);
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
    }
}