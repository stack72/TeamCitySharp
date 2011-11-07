using System;
using EasyHttp.Http;
using EasyHttp.Infrastructure;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharp.Connection
{
    internal class TeamCityCaller
    {
        private readonly Credentials _configuration = new Credentials();

        public TeamCityCaller(string hostName, bool useSsl)
        {
            if (string.IsNullOrWhiteSpace(hostName))
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

        public T Get<T>(string urlPart)
        {
            if (!_configuration.ActAsGuest && string.IsNullOrWhiteSpace(_configuration.UserName) && string.IsNullOrWhiteSpace(_configuration.Password))
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

            if (string.IsNullOrWhiteSpace(urlPart))
                throw new ArgumentException("UrlPart must be specfied");

            var request = CreateHttpRequest(_configuration.UserName, _configuration.Password);

            string url = CreateUrl(urlPart);

            try
            {
                var staticBody = request.Get(url).StaticBody<T>();
                return staticBody;
            }
            catch (HttpException httpException)
            {
                throw;
            }
        }

        private string CreateUrl(string urlPart)
        {
            var protocol = _configuration.UseSSL ? "https://" : "http://";
            
            return string.Format("{0}{1}{2}", protocol, _configuration.HostName, urlPart);
        }

        HttpClient CreateHttpRequest(string userName, string password)
        {
            var httpClient = new HttpClient();
            httpClient.Request.Accept = HttpContentTypes.ApplicationJson;
            httpClient.Request.SetBasicAuthentication(userName, password);

            return httpClient;
        }
    }
}