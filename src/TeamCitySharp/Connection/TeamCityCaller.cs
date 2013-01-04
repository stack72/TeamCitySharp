﻿using System;
using System.IO;
using System.Net;
using System.Security.Authentication;
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
            Post(data.ToString(), string.Format(urlPart, parts), string.Empty);
        }

        public void PutFormat(object data, string urlPart, params object[] parts)
        {
            Put(data.ToString(), string.Format(urlPart, parts), string.Empty);
        }

        public void DeleteFormat(string urlPart, params object[] parts)
        {
            Delete(string.Format(urlPart, parts));
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

            if (downloadHandler == null)
            {
                throw new ArgumentException("A download handler must be specfied.");
            }

            string tempFileName = Path.GetRandomFileName();
            var url = CreateUrl(string.Format(urlPart, parts));

            try
            {
                CreateHttpClient(_configuration.UserName, _configuration.Password, HttpContentTypes.ApplicationJson).GetAsFile(url, tempFileName);
                downloadHandler.Invoke(tempFileName);

            }
            finally
            {
                if (File.Exists(tempFileName))
                {
                    File.Delete(tempFileName);
                }
            }
        }

        public bool StartBackup(string urlPart)
        {
            if (CheckForUserNameAndPassword())
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

            if (string.IsNullOrEmpty(urlPart))
                throw new ArgumentException("Url must be specfied");

            var url = CreateUrl(urlPart);

            var httpClient = CreateHttpClient(_configuration.UserName, _configuration.Password, HttpContentTypes.TextPlain);
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

            var response = CreateHttpClient(_configuration.UserName, _configuration.Password, HttpContentTypes.ApplicationJson).Get(url);
            if (IsHttpError(response))
            {
                throw new HttpException(response.StatusCode, string.Format("Error {0}: Thrown with URL {1}", response.StatusDescription, url));
            }

            return response.StaticBody<T>();
        }

        public T Post<T>(string data, string urlPart)
        {
            return Post(data, urlPart, string.Empty).StaticBody<T>();
        }

        public bool Authenticate(string urlPart)
        {
            try
            {
                var httpClient = CreateHttpClient(_configuration.UserName, _configuration.Password, HttpContentTypes.TextPlain);
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

        public HttpResponse Post(string urlPart, object data, string accept)
        {
            var client = MakePostRequest(urlPart, data, accept);

            return client.Response;
        }

        public HttpResponse Put(string urlPart, object data, string accept)
        {
            var client = MakePutRequest(urlPart, data, accept);

            return client.Response;
        }

        public void Delete(string urlPart)
        {
            MakeDeleteRequest(urlPart);
        }

        private void MakeDeleteRequest(string urlPart)
        {
            var client = CreateHttpClient(_configuration.UserName, _configuration.Password, HttpContentTypes.TextPlain);
            client.Delete(CreateUrl(urlPart));
        }

        private HttpClient MakePostRequest(string urlPart, object data, string accept)
        {
            var client = CreateHttpClient(_configuration.UserName, _configuration.Password, string.IsNullOrWhiteSpace(accept) ? GetContentType(data.ToString()) : accept);

            client.Request.Accept = accept;

            client.Post(CreateUrl(urlPart), data, HttpContentTypes.ApplicationXml);

            return client;
        }

        private HttpClient MakePutRequest(string urlPart, object data, string accept)
        {
            var client = CreateHttpClient(_configuration.UserName, _configuration.Password, string.IsNullOrWhiteSpace(accept) ? GetContentType(data.ToString()) : accept);

            client.Request.Accept = accept;

            client.Put(CreateUrl(urlPart), data, HttpContentTypes.TextPlain);

            return client;
        }

        private static bool IsHttpError(HttpResponse response)
        {
            var num = (int)response.StatusCode / 100;

            return (num == 4 || num == 5);
        }

        private string CreateUrl(string urlPart)
        {
            var protocol = _configuration.UseSSL ? "https://" : "http://";
            var authType = _configuration.ActAsGuest ? "/guestAuth" : "/httpAuth";

            return string.Format("{0}{1}{2}{3}", protocol, _configuration.HostName, authType, urlPart);
        }

        private HttpClient CreateHttpClient(string userName, string password, string accept)
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

        public string GetRaw(string urlPart)
        {
            if (CheckForUserNameAndPassword())
                throw new ArgumentException("If you are not acting as a guest you must supply userName and password");

            if (string.IsNullOrEmpty(urlPart))
                throw new ArgumentException("Url must be specfied");

            var url = CreateUrl(urlPart);

            var response = CreateHttpRequest(_configuration.UserName, _configuration.Password, HttpContentTypes.TextPlain).Get(url);
            if (IsHttpError(response))
            {
                throw new HttpException(response.StatusCode, string.Format("Error {0}: Thrown with URL {1}", response.StatusDescription, url));
            }

            return response.RawText;
        }

        private bool CheckForUserNameAndPassword()
        {
            return !_configuration.ActAsGuest && string.IsNullOrEmpty(_configuration.UserName) && string.IsNullOrEmpty(_configuration.Password);
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

        private string GetContentType(string data)
        {
            if (data.StartsWith("<"))
                return HttpContentTypes.ApplicationXml;
            return HttpContentTypes.TextPlain;
        }
    }
}