using System;
using EasyHttp.Http;

namespace TeamCitySharp.Connection
{
  internal interface ITeamCityCaller
  {
    void Connect(string userName, string password, bool actAsGuest);

    T GetFormat<T>(string urlPart, params object[] parts);

    void GetFormat(string urlPart, params object[] parts);

    T PostFormat<T>(object data, string contenttype, string accept, string urlPart, params object[] parts);

    void PostFormat(object data, string contenttype, string urlPart, params object[] parts);

    void PutFormat(object data, string contenttype, string urlPart, params object[] parts);

    void DeleteFormat(string urlPart, params object[] parts);

    void GetDownloadFormat(Action<string> downloadHandler, string urlPart, params object[] parts);

    string StartBackup(string urlPart);

    T Get<T>(string urlPart);

    void Get(string urlPart);

    T Post<T>(object data, string contenttype, string urlPart, string accept);

    bool Authenticate(string urlPart, bool throwExceptionOnHttpError = true);

    HttpResponse Post(object data, string contenttype, string urlPart, string accept);

    HttpResponse Put(object data, string contenttype, string urlPart, string accept);

    void Delete(string urlPart);

    string GetRaw(string urlPart);

    bool GetBoolean(string urlPart, params object[] parts);

    void DisableCache();

    void EnableCache();
  }
}