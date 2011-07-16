using System;
using EasyHttp.Http;
using EasyHttp.Infrastructure;
using TeamCitySharpAPI.DomainEntities;

namespace TeamCitySharpAPI
{
    public class TeamCityCaller
    {
        private Credentials _configuration = new Credentials();

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
            var request = CreateHttpRequest(_configuration.UserName, _configuration.Password);

            string url = CreateUrl(urlPart);

            try
            {
                var staticBody = request.Get(url).StaticBody<T>();
                return staticBody;
            }
            catch (HttpException ex)
            {
                //do something here for an outut
                throw ex;
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