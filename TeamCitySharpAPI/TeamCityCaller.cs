using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace TeamCitySharpAPI
{
    public class TeamCityCaller
    {
        private readonly ITeamCityCredentials _configuration;

        public TeamCityCaller(ITeamCityCredentials configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException("configuration");
            _configuration = configuration;
        }


        public Uri CreateUri(string relativeUrl)
        {
            if (_configuration.UseSSL)
            {
                return new Uri(new Uri(string.Format(CultureInfo.InvariantCulture,
                                                     "https://{0}",
                                                     _configuration.HostName)),
                               relativeUrl);

            }
            else
            {
                return new Uri(new Uri(string.Format(CultureInfo.InvariantCulture,
                                                     "http://{0}",
                                                     _configuration.HostName)),
                               relativeUrl);

            }
        }


        public HttpWebRequest CreateWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            webRequest.Credentials = new NetworkCredential(_configuration.UserName,
                                                           _configuration.Password);
            webRequest.Proxy = null;
            return (webRequest);
        }


        public string Request(Uri uri)
        {
            HttpWebRequest webRequest = CreateWebRequest(uri);
            webRequest.Accept = "application/json";
            string output = string.Empty;
            try
            {


                using (var response = webRequest.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                    {
                        output = stream.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        output = stream.ReadToEnd();
                    }
                }
                else if (ex.Status == WebExceptionStatus.Timeout)
                {
                    output = "Request timeout is expired.";
                }
            }
            return output;
        }

    }
}