namespace TeamCitySharp.ActionTypes
{
  public class ActionHelper
  {
    /// <summary>
    /// Create a url with fields  
    /// </summary>
    /// <param name="url"></param>
    /// <param name="fields"></param>
    /// <returns></returns>
    public static string CreateFieldUrl(string url, string fields)
    {
      // if fields is not empty, then update the url with the fields keyword, otherwise do nothing
      if (!string.IsNullOrEmpty(fields))
      {
        if (url.Contains("?"))
          url += "&fields=" + fields;
        else
          url += "?fields=" + fields;
      }
      return url;
    }
  }
}