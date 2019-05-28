using System;

namespace TeamCitySharp.Fields
{
  public class LinkField : IField
  {
    #region Properties

    public bool Type { get; private set; }
    public bool Url { get; private set; }
    public bool RelativeUrl { get; private set; }

    #endregion

    #region Public Methods

    public static LinkField WithFields(bool type = false, bool url = false, bool relativeUrl = false)
    {
      return new LinkField
        {
          Type = type,
          Url = url, 
          RelativeUrl = relativeUrl
        };
    }

    #endregion

    #region Overrides IField

    public string FieldId
    {
      get { return "link"; }
    }

    public override string ToString()
    {
      var currentFields = String.Empty;

      FieldHelper.AddField(Type, ref currentFields, "type");

      FieldHelper.AddField(Url, ref currentFields, "url");

      FieldHelper.AddField(RelativeUrl, ref currentFields, "relativeUrl");


      return currentFields;
    }

    #endregion
  }
}